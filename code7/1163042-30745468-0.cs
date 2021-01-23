	class Program
	{
		const string to = "number@vtext.com";
		const string email = "myemail@gmail.com";
		const string password = "password";
	    const string SMTPAddress = "smtp.gmail.com";
        const int SMTPPort = 587;
		static void Main(string[] args)
		{
			Console.WriteLine("Type in the message");
			string msgBody = Console.ReadLine();
			Console.WriteLine("Sending Message...");
			SendMsg(msgBody);
			Console.WriteLine("Click Enter to continue");
			Console.Read();
		}
		
		static MailMessage InitMailMessage(string msgBody)
		{
			MailMessage message = new MailMessage();
			message.To.Add(new MailAddress(to));
			message.From = new MailAddress(email, "The Displayed Name Not The Password");
			message.Body = msgBody;
			return message;
		}
	
		static void SendMsg(string msgBody)
		{
			MailMessage msg = 	InitMailMessage(msgBody);
	
			SmtpClient smtp = new SmtpClient();
			smtp.EnableSsl = true;
			smtp.Port = SMTPPort;
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.Credentials = new System.Net.NetworkCredential(email, password);
			smtp.Host = SMTPAddress;
			try
			{	        
				smtp.Send(msg);
			}
			catch (Exception ex)
			{
				ex.Dump();
				Console.WriteLine(ex.Message);
			}
		}
		
	}
