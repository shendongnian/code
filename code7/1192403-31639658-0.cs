    public abstract class Argument : Entity<int>
    {
        public ArgumentType Type { get; set; }
        public Series Series { get; set; }
        public int Value { get; set; }
    }
    
    public class GradientArgument: Argument 
    {
        //..extra properties
    }
    
    public class LambdaArgument: Argument 
    {
        //..extra properties
    }
