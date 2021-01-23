    class ViewModel1
    {
        private ViewModel2 model2;
    
        private double _id;
        public double Id 
        {
            get { return _id; }
            set
            {
               _id= value;
               model2.Modify();           
            }
        }
    }
