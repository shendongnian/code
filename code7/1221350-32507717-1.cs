    public class MyClass
    {
        private bool TryGetNextFloat(out float nextFloat) {/* Whatever */};
        public IEnumerable<float> AsEnumerable()
        { 
            float nextFloat = 0;
            while(this.TryGetNextFloat(out nextFloat))
            {
                yield nextFloat;
            }
        }
    }
    
    // Elsewhere
    foreach (var f in myClassInstance.AsEnumerable())
    {
        // Do something with f
    }
