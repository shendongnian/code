	public partial class SteamMap
    {  
	
		private writeMessageParams mwriteMessageParams ;
		
		public virtual writeMessageParams  writeMessageParams1
		{
			get
			{
				if ((this.mwriteMessageParams == null))
				{
					this.mwriteMessageParams = new writeMessageParams();
				}
				return this.mwriteMessageParams;
			}
		}
	
		public class writeMessageParams
		{			 
			public string UIItemEditText = "test";		 
		}
    }
