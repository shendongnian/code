    public class DonationVm
    {
      public decimal Amount { set;get;}
      public string DisplayName { set;get;}
      public string Comment { set;get;}
    }
    public class DonationListVm
    {
      public DonationVm Highest { set;get;}
      public List<DonationVm> All { set;get;} 
      public DonationListVm()
      {
         this.Highest = new DonationVm();
         this.All = new List<DonationVm>();
      } 
    }
