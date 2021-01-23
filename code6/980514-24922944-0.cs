    public static void GenericImageMethod<TColor, TDepth>(Image<TColor, TDepth> frame)
                      where TColor : struct, IColor
                      where TDepth : new() 
    {
    		Image<TColor, TDepth> image_output = frame.Copy();
    		//Modify the image_output as you need...
            return image_output;
    }
