	void Example()
	{	
		Regex logRegex = new Regex(@"(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{2} )");
	
		int order = 0;
		var logs = logString.Split('\n')
							.Select(log => new 
							{
								TimeOfLog  = logRegex.Match(log).Groups[1].Value,
								LogMessage = logRegex.Replace(log, string.Empty)
							    Order = logRegex.Match(log).Success ? ++order : order
							})
							.GroupBy(log => log.Order)
							.Select(log => new Log 
							{
								TimeOfLog = DateTime.Parse(log.First().TimeOfLog),
								LogMessage = string.Join(" ", log.Select(selector => selector.LogMessage))
							});
	
	}
	
	public class Log
	{
		public DateTime TimeOfLog { get; set; }
		public string LogMessage { get; set; }
	}
	
	public const string logString = @"2015-04-22 10:08:01.99 Updated version to : 1.0.5590.18236
	2015-04-22 10:08:02.00 LOG -------------------------------------------- START
	
	2015-04-22 10:08:03.57 Server is listening at 0.0.0.0 port 25
	2015-04-22 10:08:03.61 Web Interface started on localhost:2500
	2015-04-22 10:09:29.76  >>> 220 Mailserver ready
	2015-04-22 10:09:29.78  <<< EHLO none.vi
	2015-04-22 10:09:29.81  >>> 250-Nice to meet you.
	250-8BITMIME
	250-AUTH=CRAM-MD5 PLAIN LOGIN ANONYMOUS
	250 SIZE
	2015-04-22 10:09:29.81  >>> blah blah 
	2015-04-22 10:09:29.81  >>> Relay Denied
	Spamuolus
	2015-04-22 10:09:29.81 Yadda Yadda ";
	
