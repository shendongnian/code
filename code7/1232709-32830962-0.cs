    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct CardInfoRequestHeader 
    {
        public ulong CardId;
        public byte AppListLength;
    }
    
    public struct CardInfoRequest 
    {
        public CardInfoRequestHeader Header;
        public CardApp[] AppList;
    }
    ...
    var req = new CardInfoRequest();
    req.Header = (CardInfoRequestHeader)Marshal.PtrToStructure(pData, typeof(CardInfoRequestHeader));
    req.AppList = new CardApp(req.Header.AppListLength);
    pData += Marshal.SizeOf(CardInfoRequestHeader);
    for (int ix = 0; ix < req.AppList.Length; ++ix) {
        req.AppList = (CardInfo)Marshal.PtrToStructure(pData, typeof(CardInfo));
        pData += Marshal.SizeOf(CardInfo);
    }
