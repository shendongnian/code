      public interface ITransformable<T, out S> where S : ITransformable<T, S>
        {
            S Slice(int x, int y, int width, int height);
            S Slice(Rectangle value);
            S Transpose();
            S Flip(bool horizontal, bool vertical);
            S Rotate(bool clockwise);
        }
    
        public class Mesh<T, S> : ITransformable<T, S> where S : Mesh<T,S>, ITransformable<T, S>, new()
        {
            public S Slice(int x, int y, int width, int height)
            {
                throw new NotImplementedException();
            }
    
            public S Slice(Rectangle value)
            {
                throw new NotImplementedException();
            }
    
            public S Transpose()
            {
               //The following will work smoothly.
               S sObject = this.Slice(10, 20, 30, 40);
               return sObject;
            }
            public S Flip(bool horizontal, bool vertical)
            {
                throw new NotImplementedException();
            }
    
            public S Rotate(bool clockwise)
            {
                throw new NotImplementedException();
            }
    
        }
    
        public class Heightmap : Mesh<float, Heightmap>
        {
            
        }
    
        public class Program
        {
            static void Main()
            {
                Heightmap heightmap = new Heightmap();
                Heightmap map2 = heightmap.Transpose(); //This will work smoothly.
            }
        }
