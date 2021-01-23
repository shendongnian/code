	/// <summary>
	/// Converts the mail message to memory stream. https://goo.gl/TrCqBu
	/// </summary>
	/// <param name="message">The message.</param>
	/// <returns>MemoryStream.</returns>
	public static MemoryStream ConvertMailMessageToMemoryStream(MailMessage message)
	{
		Assembly assembly = typeof(SmtpClient).Assembly;
		Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
		MemoryStream fileStream = new MemoryStream();
		ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
		object mailWriter = mailWriterContructor.Invoke(new object[] { fileStream });
		MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
		if (sendMethod.GetParameters().Length == 2)
			sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { mailWriter, true }, null);
		else
			sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { mailWriter, true, true }, null);
		MethodInfo closeMethod = mailWriter.GetType().GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);
		closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null);
		return fileStream;
	}
