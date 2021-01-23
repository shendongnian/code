    public class Network
    {
        public NetworkMatrix Win { get; set; }         // network input matrix
        public NetworkMatrix Wres { get; set; }        // network reservoir matrix
        public NetworkMatrix Wout { get; set; }        // network output matrix
        // constructor
        public Network(NetworkMatrix Winput, NetworkMatrix Wreservoir, NetworkMatrix Woutput)
        {
            Win = Winput;
            Wres = Wreservoir;
            Wout = Woutput;
        }
        ...
    }
    public class NetworkMatrix : Matrix<double>
    {
        public override string ToString()
        {
            return "Overwridden tostring method.";
        }
    }
