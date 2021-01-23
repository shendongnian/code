    public class FundsTable : ObservableCollection<Entries>
        {
            public FundsTable() { }
                   
            public FundsTable(ObservableCollection<QuantPositions> Quant_Positions, ObservableCollection<PortfolioDatePerf> Portfolio_Perf, ObservableCollection<FXData> FXDataValues, List<String> unhedgedFunds, Dictionary<String, List<String>> fundsToGroup)
            {
                FillFunds(Quant_Positions, Portfolio_Perf, FXDataValues, unhedgedFunds, fundsToGroup);
            }
                  
            /// <summary>
            /// List of funds with their values
            /// </summary>
            /// <param name="Quant_Positions">Output of DB query 1</param>
            /// <param name="Portfolio_Perf">Output of DB query 2</param>
            /// <param name="FXDataValues">Output of DB query 3</param>
            private void FillFunds(ObservableCollection<QuantPositions> Quant_Positions, ObservableCollection<PortfolioDatePerf> Portfolio_Perf, ObservableCollection<FXData> FXDataValues, List<String> unhedgedFunds, Dictionary<String, List<String>> fundsToGroup)
            {
                foreach (var element in Portfolio_Perf)
                {
                    Double LSAPNL = 0.0, SSAPNL = 0.0, FXSAPNL = 0.0, OpSAPNL = 0.0;
                    if (!element.PortfolioDesc.Equals("TB PRIME"))
                    {
                        String PortfolioGroup = fundsToGroup.Where(x => x.Value.Contains(element.PortfolioDesc)).Select(x => x.Key).FirstOrDefault();
                        Double CurrentEquity = element.CurrentEquity;
                        Double YTD = element.YTD;
                        Double MTD = element.MTD;
                        Double LExposure = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.HoldingDirection.Equals("Long") && (x.AssetType.Equals("Equity") || x.AssetType.Equals("Future") || x.AssetType.Equals("Index"))).Sum(x => x.Exposure);
                        Double SExposure = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.HoldingDirection.Equals("Short") && (x.AssetType.Equals("Equity") || x.AssetType.Equals("Future") || x.AssetType.Equals("Index"))).Sum(x => x.Exposure);
                        Double OpExposure = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.AssetType.Equals("Option")).Sum(x => x.Exposure);
                        Double FXExposure = 0.0;
                        if (unhedgedFunds.Contains(element.PortfolioDesc))
                        {
                            FXExposure = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc)).Sum(x => x.Exposure);
                        }
                        else
                        {
                            FXExposure = FXDataValues.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc)).Select(x => x.FXExposure).FirstOrDefault();
                            FXSAPNL = Double.NaN;
                        }
                        Double TExposure = LExposure + SExposure + OpExposure;
                        Double LPNL = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.HoldingDirection.Equals("Long") && (x.AssetType.Equals("Equity") || x.AssetType.Equals("Future") || x.AssetType.Equals("Index"))).Sum(x => x.PNL);
                        Double SPNL = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.HoldingDirection.Equals("Short") && (x.AssetType.Equals("Equity") || x.AssetType.Equals("Future") || x.AssetType.Equals("Index"))).Sum(x => x.PNL);
                        Double OpPNL = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && x.AssetType.Equals("Option")).Sum(x => x.PNL);
                        Double FXPNL = Quant_Positions.Where(x => x.PortfolioDesc.Equals(element.PortfolioDesc) && (x.AssetType.Equals("Cash") || x.AssetType.Equals("Currency Forwards"))).Sum(x => x.PNL);
                        Double DTD = element.DTD;
                        Double OthersPNL = DTD - (LPNL + SPNL + OpPNL + FXPNL);
                        if (LPNL != 0 && LExposure != 0)
                        {
                            LSAPNL = LPNL / LExposure;
                        }
                        if (SPNL != 0 && SExposure != 0)
                        {
                            SSAPNL = SPNL / SExposure;
                        }
                        if (OpPNL != 0 && OpExposure != 0)
                        {
                            OpSAPNL = OpPNL / OpExposure;
                        }
                        if (FXPNL != 0 && FXExposure != 0 && unhedgedFunds.Contains(element.PortfolioDesc))
                        {
                            FXSAPNL = FXPNL / FXExposure;
                        }
                        Double TSAPNL = DTD / TExposure;
                        Add(new Entries { Group = PortfolioGroup, Fund = element.PortfolioDesc, CurrentEquity = CurrentEquity, YTD = YTD, MTD = MTD, LExposure = LExposure, SExposure = SExposure, OpExposure = OpExposure, FXExposure = FXExposure, TExposure = TExposure, LPNL = LPNL, SPNL = SPNL, OpPNL = OpPNL, FXPNL = FXPNL, OtherPNL = OthersPNL, TPNL = DTD, LSAPNL = LSAPNL, SSAPNL = SSAPNL, OpSAPNL = OpSAPNL, FXSAPNL = FXSAPNL });
                    }
                }
            }
        }
