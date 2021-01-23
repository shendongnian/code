    public class MyClass
    {
        private CustomVertex.TransformedColored[] points_data;
    
        public CustomVertex.TransformedColored this[int pixelCount]
        {
           get{ return point_data[pixelCount]; }
           set{ point_data[pixelCount] = value; }
        }
    }
