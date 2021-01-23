        [Serializable]
        [DataContract]
        public class CurrRateInfo
        {
            [DataMember]
            public int CurrID { get; set; }
            [DataMember]
            public string CurrCode { get; set; }
            [DataMember]
            public double CurrRate { get; set; }
            [DataMember]
            public DateTime LastUpdate { get; set; }
        }
    Do this if you don't want a direct dependency on Json.NET from your models, and don't want to change the global behavior of asp.net.
