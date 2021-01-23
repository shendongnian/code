	public class PatronTelephones
	{
		public PatronTelephones(DataReader dr)
		{
			ContactType = dr["HomeTel1Type"].ToString();
			PhoneNumber = dr["HomeTel1"].ToString();
			
			if(Helper.PreferredContactType.Equals(Helper.HomeAddressType,StringComparison.InvariantCultureIgnoreCase)==true)
			{
				IsSMSOptIn = Convert.ToBool(dr["IsSMSSend"].ToString());
				IsCall = Convert.ToBool(dr["IsCall"].ToString());
			}
		}
		    
		public string ContactType { get; set; }
		public string Extension { get; set; } = String.Empty;
		public string PhoneNumber { get; set; }
		public bool IsSMSOptIn { get; set; } = false;
		public bool IsCall { get; set; } = false;
	}
