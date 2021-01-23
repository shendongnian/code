    public interface IMyModel
    {
        string prop1 { get; set; }
        string prop2 { get; set; }
    }
    
    public class MyObject : IMyModel
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        .....
        public string propN { get; set; }
    }
    
    IEnumerable<IMyModel> list = context.MyObject
        .Select(n => new { n.prop1, n.prop2 }) // only select these properties
        .ToArray() // execute the query
        .Select(n => (IMyModel)new MyObject { prop1 = n.prop1, prop2 = n.prop2 }); // construct our desired object
