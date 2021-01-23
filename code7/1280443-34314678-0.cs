    public interface IControlWithLabel
    {
        Label Label { get; }
    }
    
    public interface IControlWithLabel<TControl> : IControlWithLabel where TControl : Control, new()
    {  
        TControl Control { get;}
    }
    
    //never instantiated, common base
    public abstract class ControlWithLabel : IControlWithLabel
    {
    }
    
    public class ControlWithLabel<TControl> : ControlWithLabel, IControlWithLabel<TControl>
    {
    }
