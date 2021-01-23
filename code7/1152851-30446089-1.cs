         //Must set Synchonization Context of the current UI thread otherswise system will throw CrossThread-Exception when tryin gto add/remove a record from the BindingList
            switch (_dsoType)
            {
                case DSOType.Portfolio:
                    {
                        ThreadedBindingList<DSOPortfolio> list = _ds.DSORepository.PortfolioBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged += new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                case DSOType.Instrument:
                    {
                        ThreadedBindingList<DSOInstrument> list = _ds.DSORepository.InstrumentBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged += new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                case DSOType.Trade:
                    {
                        ThreadedBindingList<DSOTrade> list = _ds.DSORepository.TradeBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged +=new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                case DSOType.ClosedTrade:
                    {
                        ThreadedBindingList<DSOClosedTrade> list = _ds.DSORepository.ClosedTradeBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged += new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                case DSOType.Order:
                    {
                        ThreadedBindingList<DSOOrder> list = _ds.DSORepository.OrderBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged += new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                case DSOType.Position:
                    {
                        ThreadedBindingList<DSOPosition> list = _ds.DSORepository.PositionBindingList;
                        list.SynchronizationContext = SynchronizationContext.Current;
                        dgvMain.DataSource = list;
                        list.ListChanged += new ListChangedEventHandler(list_ListChanged);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
