    public string Subject
		{
			get
			{
                return (yt.Message.Length > 255) ? yt.Message.Substring(0, 255) : yt.Message
            }
		}
