    class Program
    {
        public void Main(string[] args)
        {
            //the size of the network
            int size = 5;
            //create array of Neurons
            BaseNeuron[] network = new BaseNeuron[size];
            for(int i = 0; i < network.length; i++)
            {
                //actually create a new nueron (instantiate them)
                network[i] = new BaseNeuron();
                //link up neurons together, etc
            }
        }
    }
