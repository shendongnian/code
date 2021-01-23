    public sealed class SomeEventArgs : EventArgs
    {
        private readonly string address;
        public Uri Uri => new Uri(address);
        
        public SomeEventArgs(string address)
        {
            this.address = address;
        }
    }
---
    // If the address is not formatted property, 
    // trying to get the `Uri` will cause an exception to be thrown: 
    var e = new SomeEventArgs("qwe'1231[e);");
    
    // But, we can use to reflection to find out what private fields are,
    // and possibly dug out something interesting
    var fields = typeof(SomeEventArgs).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(x => new { x.Name, x.FieldType });
    
    // Say if you find something interesting, like 'address',
    // you can retrieve its value like this
    var address = typeof(SomeEventArgs).GetField("address", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(e);
