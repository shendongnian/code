    [DataContract]
    public class Root
    {
		[DataMember]
        public int total { get; set; }
		[DataMember]
        public int start { get; set; }
		[DataMember]
        public int next { get; set; }
		[DataMember]
        public IList<Datum> data { get; set; }
    }
    [DataContract]	
    public class Datum
    {
	    [DataMember]
        public string idfile { get; set; }
		[DataMember]
        public string judul { get; set; }
		[DataMember]
        public string sku { get; set; }
		[DataMember]
        public string tipe { get; set; }
		[DataMember]
        public string nama_tipe { get; set; }
		[DataMember]
        public string gratis { get; set; }
		[DataMember]
        public string hrg { get; set; }
		[DataMember]
        public string katid { get; set; }
		[DataMember]
        public string nfile { get; set; }
		[DataMember]
        public BundleFile bundle_file { get; set; }
		[DataMember]
        public string tgl { get; set; }
		[DataMember]
        public string ufile { get; set; }
		[DataMember]
        public string deskripsi { get; set; }
		[DataMember]
        public string isLokal { get; set; }
    }
    [DataContract]
    public class BundleFile
    {
	    [DataMember]
        public string bundle_file { get; set; }
		[DataMember]
        public string path_file { get; set; }
		[DataMember]
        public string pwd_file { get; set; }
    }
