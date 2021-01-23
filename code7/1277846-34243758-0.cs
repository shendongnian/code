      public class Imageinfo
    			{
    				public string thumburl { get; set; }
    				public int thumbwidth { get; set; }
    				public int thumbheight { get; set; }
    				public string url { get; set; }
    				public string descriptionurl { get; set; }
    			}
    	
    			public class Pageval
    			{
    				public int ns { get; set; }
    				public string title { get; set; }
    				public string missing { get; set; }
    				public string imagerepository { get; set; }
    				public List<Imageinfo> imageinfo { get; set; }
    			}
    
    
        		public class Query
                {
                    public Dictionary<string, Pageval> pages { get; set; }
                }
    
                public class RootObject
                {
                    public string batchcomplete { get; set; }
                    public Query query { get; set; }
                }
    
    
    			public class Image
    			{
    				public static PictureBox Image1 = new PictureBox();
    				public static PictureBox Image2 = new PictureBox();
    				public static PictureBox Image3 = new PictureBox();    			
    			
    			}
