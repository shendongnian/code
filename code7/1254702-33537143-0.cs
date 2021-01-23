	public class Alternativeaddress2
	{
		public string id { get; set; }
		public string user_type_id { get; set; }
		public string last_updated_by { get; set; }
		public object code { get; set; }
		public string card { get; set; }
		public string user_name { get; set; }
		public string password { get; set; }
		public string mobile { get; set; }
		public string email { get; set; }
		public string ip_address { get; set; }
		public string last_activity { get; set; }
		public string is_active { get; set; }
		public string last_update { get; set; }
		public string api_key { get; set; }
		public object card_type_id { get; set; }
	}
	public class Result
	{
		public List<Alternativeaddress2> alternativeaddress { get; set; }
	}
	public class AlternativeAddress
	{
		public bool SUCCESS { get; set; }
		public Result result { get; set; }
	}
	public class Getitem
	{
		public AlternativeAddress alternativeAddress { get; set; }
	}
	public class RESPONSE
	{
		public Getitem getitem { get; set; }
	}
	public class RootObject
	{
		public RESPONSE RESPONSE { get; set; }
	}
