    protected void stationSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(stationSelect.SelectedValue == "0")
            {
                string OrePriceA = "http://api.eve-central.com/api/marketstat?typeid=34&minQ=1&typeid=35&minQ=1&typeid=36&minQ=1&typeid=37&minQ=1&typeid=38&minQ=1&typeid=39&minQ=1&typeid=40&minQ=1&typeid=11399&minQ=1&usesystem=30002187";
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(OrePriceA);
                TriPrAmarB.Text = GetStat(xdoc, 34, TranType.Buy, StatType.Max);
                TriPrAmarS.Text = GetStat(xdoc, 34, TranType.Sell, StatType.Max);
                PyrPrAmarB.Text = GetStat(xdoc, 35, TranType.Buy, StatType.Max);
                PyrPrAmarS.Text = GetStat(xdoc, 35, TranType.Sell, StatType.Max);
                MexPrAmarB.Text = GetStat(xdoc, 36, TranType.Buy, StatType.Max);
                MexPrAmarS.Text = GetStat(xdoc, 36, TranType.Sell, StatType.Max);
                IsoPrAmarB.Text = GetStat(xdoc, 37, TranType.Buy, StatType.Max);
                IsoPrAmarS.Text = GetStat(xdoc, 37, TranType.Sell, StatType.Max);
                NocPrAmarB.Text = GetStat(xdoc, 38, TranType.Buy, StatType.Max);
                NocPrAmarS.Text = GetStat(xdoc, 38, TranType.Sell, StatType.Max);
                ZydPrAmarB.Text = GetStat(xdoc, 39, TranType.Buy, StatType.Max);
                ZydPrAmarS.Text = GetStat(xdoc, 39, TranType.Sell, StatType.Max);
                MegPrAmarB.Text = GetStat(xdoc, 40, TranType.Buy, StatType.Max);
                MegPrAmarS.Text = GetStat(xdoc, 40, TranType.Sell, StatType.Max);
                MorPrAmarB.Text = GetStat(xdoc, 11399, TranType.Buy, StatType.Max);
                MorPrAmarS.Text = GetStat(xdoc, 11399, TranType.Sell, StatType.Max);
            }
            if(stationSelect.SelectedValue == "1")
            {
                string OrePriceH = "http://api.eve-central.com/api/marketstat?typeid=34&minQ=1&typeid=35&minQ=1&typeid=36&minQ=1&typeid=37&minQ=1&typeid=38&minQ=1&typeid=39&minQ=1&typeid=40&minQ=1&typeid=11399&minQ=1&usesystem=30003394";
                XmlDocument xdocH = new XmlDocument();
                xdocH.Load(OrePriceH);
                TriPrAmarB.Text = GetStat(xdocH, 34, TranTypeH.Buy, StatTypeH.Max);
                TriPrAmarS.Text = GetStat(xdocH, 34, TranTypeH.Sell, StatTypeH.Max);
                PyrPrAmarB.Text = GetStat(xdocH, 35, TranTypeH.Buy, StatTypeH.Max);
                PyrPrAmarS.Text = GetStat(xdocH, 35, TranTypeH.Sell, StatTypeH.Max);
                MexPrAmarB.Text = GetStat(xdocH, 36, TranTypeH.Buy, StatTypeH.Max);
                MexPrAmarS.Text = GetStat(xdocH, 36, TranTypeH.Sell, StatTypeH.Max);
                IsoPrAmarB.Text = GetStat(xdocH, 37, TranTypeH.Buy, StatTypeH.Max);
                IsoPrAmarS.Text = GetStat(xdocH, 37, TranTypeH.Sell, StatTypeH.Max);
                NocPrAmarB.Text = GetStat(xdocH, 38, TranTypeH.Buy, StatTypeH.Max);
                NocPrAmarS.Text = GetStat(xdocH, 38, TranTypeH.Sell, StatTypeH.Max);
                ZydPrAmarB.Text = GetStat(xdocH, 39, TranTypeH.Buy, StatTypeH.Max);
                ZydPrAmarS.Text = GetStat(xdocH, 39, TranTypeH.Sell, StatTypeH.Max);
                MegPrAmarB.Text = GetStat(xdocH, 40, TranTypeH.Buy, StatTypeH.Max);
                MegPrAmarS.Text = GetStat(xdocH, 40, TranTypeH.Sell, StatTypeH.Max);
                MorPrAmarB.Text = GetStat(xdocH, 11399, TranTypeH.Buy, StatTypeH.Max);
                MorPrAmarS.Text = GetStat(xdocH, 11399, TranTypeH.Sell, StatTypeH.Max);
            }
            if(stationSelect.SelectedValue == "2")
            {
                string OrePriceD = "http://api.eve-central.com/api/marketstat?typeid=34&minQ=1&typeid=35&minQ=1&typeid=36&minQ=1&typeid=37&minQ=1&typeid=38&minQ=1&typeid=39&minQ=1&typeid=40&minQ=1&typeid=11399&minQ=1&usesystem=30002659";
                XmlDocument xdocD = new XmlDocument();
                xdocD.Load(OrePriceD);
                TriPrAmarB.Text = GetStat(xdocD, 34, TranTypeD.Buy, StatTypeD.Max);
                TriPrAmarS.Text = GetStat(xdocD, 34, TranTypeD.Sell, StatTypeD.Max);
                PyrPrAmarB.Text = GetStat(xdocD, 35, TranTypeD.Buy, StatTypeD.Max);
                PyrPrAmarS.Text = GetStat(xdocD, 35, TranTypeD.Sell, StatTypeD.Max);
                MexPrAmarB.Text = GetStat(xdocD, 36, TranTypeD.Buy, StatTypeD.Max);
                MexPrAmarS.Text = GetStat(xdocD, 36, TranTypeD.Sell, StatTypeD.Max);
                IsoPrAmarB.Text = GetStat(xdocD, 37, TranTypeD.Buy, StatTypeD.Max);
                IsoPrAmarS.Text = GetStat(xdocD, 37, TranTypeD.Sell, StatTypeD.Max);
                NocPrAmarB.Text = GetStat(xdocD, 38, TranTypeD.Buy, StatTypeD.Max);
                NocPrAmarS.Text = GetStat(xdocD, 38, TranTypeD.Sell, StatTypeD.Max);
                ZydPrAmarB.Text = GetStat(xdocD, 39, TranTypeD.Buy, StatTypeD.Max);
                ZydPrAmarS.Text = GetStat(xdocD, 39, TranTypeD.Sell, StatTypeD.Max);
                MegPrAmarB.Text = GetStat(xdocD, 40, TranTypeD.Buy, StatTypeD.Max);
                MegPrAmarS.Text = GetStat(xdocD, 40, TranTypeD.Sell, StatTypeD.Max);
                MorPrAmarB.Text = GetStat(xdocD, 11399, TranTypeD.Buy, StatTypeD.Max);
                MorPrAmarS.Text = GetStat(xdocD, 11399, TranTypeD.Sell, StatTypeD.Max);
            }
        }
