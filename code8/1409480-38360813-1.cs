    public class MyEntities : DbContext {
        public MyEntities() : base("ConnectionName1") {}
    }
    
    // calling code now never has to know about the connection
    using(var myEntities = new MyEntities()) { /* do something here */}
