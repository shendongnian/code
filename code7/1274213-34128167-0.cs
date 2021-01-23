	public class Rootobject
	{
		public string code { get; set; }
		public string message { get; set; }
		public Data data { get; set; }
	}
	public class Data
	{
		public Attributes attributes { get; set; }
		public int blacklisted { get; set; }
		public string email { get; set; }
		public string entered { get; set; }
		public int[] listid { get; set; }
		public Message_Sent[] message_sent { get; set; }
		public Hard_Bounces[] hard_bounces { get; set; }
		public object[] soft_bounces { get; set; }
		public Spam[] spam { get; set; }
		public Unsubscription unsubscription { get; set; }
		public Opened[] opened { get; set; }
		public object[] clicks { get; set; }
		public Transactional_Attributes[] transactional_attributes { get; set; }
		public int blacklisted_sms { get; set; }
	}
	public class Attributes
	{
		public string EMAIL { get; set; }
		public string NAME { get; set; }
		public string SURNAME { get; set; }
	}
	public class Unsubscription
	{
		public User_Unsubscribe[] user_unsubscribe { get; set; }
		public Admin_Unsubscribe[] admin_unsubscribe { get; set; }
	}
	public class User_Unsubscribe
	{
		public string event_time { get; set; }
		public int camp_id { get; set; }
		public string ip { get; set; }
	}
	public class Admin_Unsubscribe
	{
		public string event_time { get; set; }
		public string ip { get; set; }
	}
	public class Message_Sent
	{
		public int camp_id { get; set; }
		public string event_time { get; set; }
	}
	public class Hard_Bounces
	{
		public int camp_id { get; set; }
		public string event_time { get; set; }
	}
	public class Spam
	{
		public int camp_id { get; set; }
		public string event_time { get; set; }
	}
	public class Opened
	{
		public int camp_id { get; set; }
		public string event_time { get; set; }
		public string ip { get; set; }
	}
	public class Transactional_Attributes
	{
		public string ORDER_DATE { get; set; }
		public int ORDER_PRICE { get; set; }
		public string ORDER_ID { get; set; }
	}
