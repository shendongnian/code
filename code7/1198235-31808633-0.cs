    using MicroMvvm;
	
    public AuctionsViewModel : ObservableObject
    {
		private string user;
		private int auction;
		private ObservableCollection<int> auctions;
		
		public string User
		{
			get{return user;}
			set			
			{
				if(user!=value)
				{
					user=value;
					RaisePropertyChanged("User");
				}				
			}
		}
		
		public int Auction
		{
			get{return auction;}
			set			
			{
				if(auction!=value)
				{
					auction=value;
					RaisePropertyChanged("Auction");
				}				
			}
		}
		
		public ObservableCollection<int> Auctions
		{
			get{return auctions;}
			set			
			{
				if(auctions!=value)
				{
					auctions=value;
					RaisePropertyChanged("Auctions");
				}				
			}
		}
		
		public ICommand Bid
		{
			get{return new RelayCommand(BidExecute);}
		}
		
		private void BidExecute()
		{
			Auction++;
			using (SqlConnection conn = new SqlConnection(@" Data source=ALASAD; Initial Catalog=aukcija_Arsen_Milosev; Integrated Security = true;"))
			{
				conn.Open();
				using (SqlCommand comm = new SqlCommand("UPDATE auctions SET bidValue = @bidvalue, lastBider = @lastbider",conn))
				{
					comm.Parameters.AddWithValue("@lastbider", User);
					comm.Parameters.AddWithValue("@bidValue", Auction);
					comm.ExecuteNonQuery();
					conn.Close();
				}
			}
			Auctions.clear();			
			showData sd = new showData();
			Auctions.AddRange(sd.toString());
			RaisePropertyChanged("Auctions");
		}
    }
	
	
