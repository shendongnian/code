    string OrePrice = "http://api.eve-central.com/api/marketstat?typeid=34&minQ=1&typeid=35&minQ=1&typeid=36&minQ=1&typeid=37&minQ=1&typeid=38&minQ=1&typeid=39&minQ=1&typeid=40&minQ=1&typeid=11399&minQ=1&usesystem=30002187";
    
    XmlDocument xdoc = new XmlDocument();
    xdoc.Load(OrePrice);
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
    MegPrAmarB.Text = GetStat(xdoc, 40, TranType.Buy, StatType.Max);
    MegPrAmarS.Text = GetStat(xdoc, 40, TranType.Sell, StatType.Max);
