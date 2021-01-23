    public class MyClass
    {
        private List<float> data = new List<float>(); // whatever values
        public IEnumerable<float> AsEnumerable()
        { 
            foreach (var f in data)
            {
                yield f; 
            }
        }
    }
    
    // Elsewhere
    foreach (var f in myClassInstance.AsEnumerable())
    {
        // Do something with f
    }
