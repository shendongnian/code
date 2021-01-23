    [TLObject(0x818426CD)]
    public partial class PeerSettings : IPeerSettings
    {
        [TLProperty(1)]
        public int Flags { get; set; }
    
        [TLProperty(2)]
        public bool ReportSpam { get; set; }
    
    }
