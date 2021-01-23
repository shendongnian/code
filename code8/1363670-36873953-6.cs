	public class Picture {
		public int PIC_ID { get; set; }
		public string pic_name { get; set; }
		public Nullable<int> belong_id { get; set; }
		public byte[] pic { get; set; }
	}
	public class service_provider {
		public int SPID { get; set; }
		public string Sp_email { get; set; }
		public string Sp_password { get; set; }
		public string Sp_name { get; set; }
		
		// added
		public ICollection<Picture> Pictures {get;set;}
	}
