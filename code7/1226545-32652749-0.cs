    public interface ILayer
    {
        void pop_in();
    }
    
    // one of your classes
    public class SomeLayer : ILayer
    {
        // ...
    }
    
    //object for store active layer
    ILayer active_layer = new SomeLayer();
    
    // rest of the code works
