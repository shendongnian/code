    interface INonGenericInterface
    {
        void PerformService(); 
    }
    interface IGenericInterface<T>: INonGenericInterface
    {
        T GenericTypeProperty {get; set;}
    }
    public class ServeThem
    {
        INonGenericInterface Server {get; set;}
    }
