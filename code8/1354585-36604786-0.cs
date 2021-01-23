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
        //costs that are available to the user. These get updated when quality etc is changed
        private ObservableCollection<string> availableCosts;
        public ObservableCollection<string> AvailableCosts
        {
            get { return availableCosts; }
            set
            {
                if (availableCosts != value)
                {
                    availableCosts = value;
                    OnPropertyChanged("AvailableCosts");
                }
            }
        }
        public void UpdateCost()
        {
            //remove the old available options
            AvailableCosts.Clear();
            //add the new ones
            if (Quality == "high" && Product == "stazione1")
            {
                AvailableCosts.Add("abc");
                AvailableCosts.Add("def");
            }
            //make sure our current cost is in the list by just making it the first one
            Cost = AvailableCosts[0];
        }
