    public interface IApiVersion {
        //the public method signatures
    }
    
    public interface IApiVersionFactory {
        IApiVersion Create(int version);
    }
