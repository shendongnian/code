    [ServiceContract]
    public interface ICalculate
    {
       [OperationContract]
       double Add( double a, double b);
       [OperationContract]
       double Subtract( double a, double b);
    }
