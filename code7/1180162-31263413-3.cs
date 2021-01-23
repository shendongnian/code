    // general interface for abstract factory (this is optional)
    public abstract class AbstractFactory { };
     
    // interface that uses a type of factory and produce abstract product
    public abstract class AbstractChocolateFactory : AbstractFactory  { };
    
    // family of concrete factories that produce concrete products
    public class NestleChocolateFactory { } : AbstractChocolateFactory 
    public class SwissChocolateFactory { } : AbstractChocolateFactory 
