    class Routes : INotifyPropertyChanged
    {
        private string product;
        public string Product
        {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;
                    OnPropertyChanged("Product");
                }
            }
        }
        
        private string operation;
        public string Operation
        {
            get { return operation; }
            set
            {
                if (operation != value)
                {
                    operation = value;
                    UpdateCost();
                    OnPropertyChanged("Operation");
                }
            }
        }
        
        private string quality;
        public string Quality
        {
            get { return quality; }
            set
            {
                if (quality != value)
                {
                    quality = value;
                    UpdateCost();
                    OnPropertyChanged("Quality");
                }
            }
        }
        
        private double cost;
        public double Cost
        {
            get { return cost; }
            set
            {
                if (cost != value)
                {
                    cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }
        public void UpdateCost()
        {
            double qualityMultiple = 1;
            switch (Quality)
            {
                case "high":
                    qualityMultiple = 1.5;
                    break;
                case "medium":
                    qualityMultiple = 1;
                    break;
                case "low":
                    qualityMultiple = 0.5;
                    break;
            }
            switch (Operation)
            {
                case "cleaning":
                    Cost = 10 * qualityMultiple;
                    break;
                case "washing":
                    Cost = 15 * qualityMultiple;
                    break;
                case "drying":
                    Cost = 12.5 * qualityMultiple;
                    break;
            }
        }
    }
