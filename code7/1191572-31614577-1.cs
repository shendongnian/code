    public class MyClass
    {
        private CustomVertex.TransformedColored[] points_data;
    
        public CustomVertex.TransformedColored this[int pixelCount]
        {
           get{ return points_data[pixelCount]; }
           set{ points_data[pixelCount] = value; }
        }
    }
