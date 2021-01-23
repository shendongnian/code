    /* Common interface each object shares */
    public interface IObject { ... }
    /* Sharable Object implementing IObject */
    public class Cup : IObject { ... }
    
    /* This class would be exposed via WCF or Remoting */
    public class ObjectSharer : IObjectSharer {
    	enum ObjectType { Cup, Car }
    	IObject GetObject(ObjectType ObjType) { ... }
    	ReturnObj(IObject) { ... }
    }
