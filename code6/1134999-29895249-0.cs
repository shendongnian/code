    public class LED{
	   Bitmap bmp;
	   public LED(Bitmap bmp){
		  this.bmp = bmp;
	   }
	}
	public static class LEDSingleton
    {
	    private static Dictionary<string,LED> LEDs = new Dictionary<string, LED>();
        public static LED Instance(string name, Bitmap bmp)
	    {
            if (!LEDs.ContainsKey(name))
            {
                LEDs.Add(name, new LED(bmp));
            }
            return LEDs[name];
	    }
    }
