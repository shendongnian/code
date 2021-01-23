			CriaService("xpto@gmail.com");
			var msg = new AE.Net.Mail.MailMessage
			{
				Subject = "Your Subject",
				Body = "Hello, World, from Gmail API!",
				From = new MailAddress("xpto@gmail.com")
			};
			msg.To.Add(new MailAddress("someone@gmail.com"));
			msg.ReplyTo.Add(msg.From); 
			var msgStr = new StringWriter();
			msg.Save(msgStr);
			
			Message m = new Message();
			m.Raw = Base64UrlEncode(msgStr.ToString());
			var draft = new Draft();
			draft.Message = m;
			
			try
			{
				Service.Users.Drafts.Create(draft, "xpto@opportunity.com.br").Execute();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
