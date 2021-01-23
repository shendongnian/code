    public class Foo : IDisposable
    {
        private Image image;
    
        public void Dispose()
        {
            if(image != null)
               image.Dispose();
        }
    }
