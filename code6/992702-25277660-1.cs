    using artisan.Attributes;
    
    public class UploadImageModel
    {
    	[FileSize(10240)]
    	[FileTypes("jpg,jpeg,png")]
    	public HttpPostedFileBase File { get; set; }
    }
