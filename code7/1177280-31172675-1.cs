    public class TransferService : ITransferService
	{
	
    	private string _path;
    	public TransferService(string path) {
    		_path  = path
    	}
    	
    	public File DownloadDocument()
		{
		    File file = new File();
		    //String path = txtSelectFilePath.Text;
		    file.Content = System.IO.File.ReadAllBytes(_path);
		    //file.Name = "ImagingDevices.exe";
		
		    return file;
		}
	}
