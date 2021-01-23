    public class AvailabilityDataWithoutAging
    {
        public string BranchPlant { get; set; }
        public string Location { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int PiecesPerPalletMaster { get; set; }
        public int NumberOfLots { get; set; }
        public int NumberOfPalletsConversion
        {
          get
          {
              return AvailablePrimary/PiecesPerPalletMaster;
          }
        }
        public int AvailablePrimary { get; set; }
        public int TempPrimary { get; set; }
        public int BlankPrimary { get; set; }
        public int HoldAutomaticPrimary { get; set; }
        public int HoldSpecificPrimary { get; set; }
    }
