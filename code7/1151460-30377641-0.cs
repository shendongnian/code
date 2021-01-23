        [Serializable]
        public class SiteBinding
        {
            public BindingType type { get; set; }
            public string hostName { get; set; }
            public int? port { get; set; }
            [Serializable] //remove this line
            public BindingIP ip { get; set; }
            public string sslCertificate { get; set; }
        }
