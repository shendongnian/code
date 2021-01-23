	public class SmtpEvent
		{
			public int ts { get; set; }
			public DateTime SmtpTs { get; set; }
			public string type { get; set; }
			public string diag { get; set; }
			public string source_ip { get; set; }
			public string destination_ip { get; set; }
			public int size { get; set; }
			public int smtpId { get; set; } //added for datalayer
		}
		public class Msg
		{
			public int ts { get; set; }
			public DateTime MsgTs { get; set; }
			public string _id { get; set; }
			public string state { get; set; }
			public string subject { get; set; }
			public string email { get; set; }
			public List<object> tags { get; set; }
			public List<object> opens { get; set; } //an array of containing an item for each time the message was opened. Each open includes the following keys: "ts", "ip", "location", "ua"
			public List<object> clicks { get; set; } //an array containing an item for each click recorded for the message. Each item contains the following: "ts", "url"
			public List<SmtpEvent> smtp_events { get; set; }
			public List<object> resends { get; set; } //not currently documented on http://help.mandrill.com/entries/58303976-Message-Event-Webhook-format
			public string _version { get; set; }
			public string diag { get; set; } //for bounced and soft-bounced messages, provides the specific SMTP response code and bounce description, if any, received from the remote server
			public int bgtools_code { get; set; } //Is it this? for bounced and soft-bounced messages, a short description of the bounce reason such as bad_mailbox or invalid_domain. (not currently documented but in JSON response)
			public string sender { get; set; }
			public object template { get; set; }
			public string bounce_description { get; set; }
			public Msg()
			{
				tags = new List<object>();
				opens = new List<object>();
				clicks = new List<object>();
				smtp_events = new List<SmtpEvent>();
				smtp_events.Add(new SmtpEvent());
				resends = new List<object>();
			}
		}
		public class MandrillEvent
		{
			public string @event { get; set; }
			public string _id { get; set; }
			public Msg msg { get; set; }
			public int ts { get; set; }
			public DateTime MandrillEventTs { get; set; }
			public int messageId { get; set; } //added for datalayer
			public List<string> SingleMandrillEventData { get; set; } //added for Reporting
			public MandrillEvent()
			{
				SingleMandrillEventData = new List<string>();
				msg = new Msg();
			}
		}
