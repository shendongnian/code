    interface IGuardArgument 
    { 
      object Value { get; }
      strign Name { get; }
    }
    
    public class GuardArgument<T> : IGuardArgument
    {
      // Explicit implementation to hide this property from
      // intellisense.
      object IGuardArgument.Value { get { return Value; } 
    
      // Rest of class here, including public properties Value and Name.
    }
