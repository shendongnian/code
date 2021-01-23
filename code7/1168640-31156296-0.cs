    public class WCFClientProxy<IServiceContract> : ClientBase<IServiceContract> where IServiceContract : class
    {
    	public IServiceContract Instance
    	{
    		get { return base.Channel; }
    	}
    }
    
    public string UploadFile(decimal maxFileSize, AttachmentFileParams fileParams, Stream file)
    {
    	try
    	{
    		if (file.Length > (maxFileSize * 1024)) //maxFileSize is defined in KB and file.Length is in Bytes
    			return Serialization.ConvertToJson(new { IsError = true, ErrorMessage = Constants.Messages.MaxFileSizeExceeded + maxFileSize });
    
    		string jsonFile = Serialization.ConvertToJson(fileParams);
    		byte[] jsonFileBytes = Encoding.UTF8.GetBytes(jsonFile);
    		byte[] len = BitConverter.GetBytes(jsonFileBytes.Length);
    		byte[] bufferRead = new byte[checked((uint)Math.Min(4096, (int)jsonFileBytes.Length + file.Length))];
    		int bytesReadCount;
    
    		using (Stream stream = new MemoryStream())
    		{
    			stream.Write(len, 0, len.Length);
    			stream.Write(jsonFileBytes, 0, jsonFileBytes.Length);
    
    			while ((bytesReadCount = file.Read(bufferRead, 0, bufferRead.Length)) > 0)
    			{
    				stream.Write(bufferRead, 0, bytesReadCount);
    			}
    			stream.Position = 0;
    			WCFClientProxy<Attachment.Interfaces.IAttachmentService> proxy = new WCFClientProxy<Attachment.Interfaces.IAttachmentService>();
    			return proxy.Instance.UploadFile(stream);
    		}
    	}
    	catch (Exception ex)
    	{
    		return Serialization.ConvertToJson(new { IsError = true, ErrorMessage = ex.Message });
    	}
    }
