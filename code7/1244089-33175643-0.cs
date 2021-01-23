    public static class ImageHelpers
    {
    	punlic byte[] ConvertFromBase64(btye[] data)
    	{
    		return Convert.FromBase64String(data)
    	}
    	
        public  Image Rotate90FromData(byte[] data)
        {
            if (Data != null)
            {             
                BitmapImage _ImageBitmap = new BitmapImage();
                _ImageBitmap.BeginInit();
                _ImageBitmap.StreamSource = new MemoryStream(data);
                _ImageBitmap.EndInit();
    
                image.Source = _ImageBitmap;
    
                // If the image is portrait, rotate it
                if( image.Source.Width < image.Source.Height)
                {
                    RotateTransform _RotateTransform = new RotateTransform(90);
                    image.RenderTransform = _RotateTransform;
                }
    			
    			return Image;
            }
        }
    }
    
    public class Main
    {
    	public void Start()
    	{
    		var data64 = ImageHelpers.ConvertFromBase64(somevar);
    		Image rotatedImage = ImageHelpers.Rotate90FromData(data64);
    		
    	}
    }
