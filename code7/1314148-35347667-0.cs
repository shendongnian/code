    public class Box 
    {
        int Width;
        int Height;
        int Length;
    
        public Box(int width, int height, int length)
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }
    }
    
    public class ProductBox : Box
    {
        string Name;
    	
    	public ProductBox(string Name, int width, int height, int length)
    		: base(width, height, length)
    	{
    		this.Name = Name;
    	}
    	
        public static ProductBox[] GetInfo(string filePath)
        {
            var engine = new FileHelperEngine<ProductBox>();
            var result = engine.ReadFile(filePath);
            return result;
        }
    }
