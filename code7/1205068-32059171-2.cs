	public class CreateMessageAttachments : ICommand
	{
	    public Guid MessageId { get; set; }
	    public string Foo { get; set; }
	    public string Bar { get; set; }
	    public IList<CreateAttachment> Attachments { get; set; }
	}
	public class CreateAttachment : ICommand
	{
	    public string Data { get; set; }
	    public string Filename { get; set; }
	    public string Type { get; set; }
	    public string GetBase64()
	    {
	        if (string.IsNullOrWhiteSpace(Data))
	            return null;
	        var index = Data.LastIndexOf("base64");
	        if (index == -1)
	            return Data;
	        return Data.Substring(index + 7);
	    }
	    public byte[] GetByteArray()
	    {
	        try
	        {
	            var base64 = GetBase64();
	            if (string.IsNullOrWhiteSpace(base64))
	                return null;
	            return Convert.FromBase64String(base64);
	        }
	        catch
	        {
	            return null;
	        }
	    }
	}
