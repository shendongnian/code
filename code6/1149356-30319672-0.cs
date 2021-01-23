    public class ImageAdd   
    {
    	public Guid ImageAddId { get; set; }
    	public byte[] Image { get; set; }
    
    	public System.Drawing.Image ImageData
    	{
    		System.Drawing.Image result = null;
    		using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
    		{
    			ms.Write(bArray, 0, bArray.Length);
    			result = System.Drawing.Image.FromStream(ms, true);
    		}
    		return result;
    	}
    }
