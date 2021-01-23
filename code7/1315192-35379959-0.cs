    class TrainSignal
    {
        public delegate void TrainsAComing(); // The delegate type
    
        public TrainsAComing OnTrainsAComing; // The member of delegate type
    
        public void HerComesATrain()
        {
            OnTrainsAComing();
        }
    }
