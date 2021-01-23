      [DataContract]
      public class YourResponse
    {
		[DataMember]
		public bool Success { get; set; }
        
		[DataMember]
        public categories Categories{ get; set; }
    }
