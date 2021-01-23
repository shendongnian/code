    if (!allowUnicode && !MimeBasePart.IsAscii(this.userName, true))
	{
		throw new SmtpException(SR.GetString("SmtpNonAsciiUserNotSupported", new object[]
		{
			this.Address
		}));
	}
