        //cost that's selceted by the user
        private string cost;
        public string Cost
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
