    public interface IBaseQuery {
        string getOperationName(); // your common operation 
    }
    
    public interface IQuery<In, Out>: IBaseQuery {
    }
