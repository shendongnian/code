    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace Sandpit
    {
        public class Routing : INotifyPropertyChanged
        {
            private ObservableCollection<string> availableProducts;
            public ObservableCollection<string> AvailableProducts
            {
                get { return availableProducts; }
                set
                {
                    if (availableProducts != value)
                    {
                        availableProducts = value;
                        OnPropertyChanged("AvailableProducts");
                    }
                }
            }
            private string product;
            public string Product
            {
                get { return product; }
                set
                {
                    if (product != value)
                    {
                        product = value;
                        UpdateAvailableCosts();
                        OnPropertyChanged("Product");
                    }
                }
            }
            private ObservableCollection<string> availableQuality;
            public ObservableCollection<string> AvailableQuality
            {
                get { return availableQuality; }
                set
                {
                    if (availableQuality != value)
                    {
                        availableQuality = value;
                        OnPropertyChanged("AvailableQuality");
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
                        UpdateAvailableCosts();
                        OnPropertyChanged("Quality");
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
            
            public void UpdateAvailableCosts()
            {
                //remove the old available options
                AvailableCosts.Clear();
                //populate it with just two items made up of the quality and cost for demo
                AvailableCosts.Add(Quality + Product);
                AvailableCosts.Add(Product + Quality);
                //make sure our current cost is in the list by just clearing it
                Cost = "";
            }
    
            public Routing()
            {
                AvailableProducts = new ObservableCollection<string> { "A", "B" };
                AvailableQuality = new ObservableCollection<string> { "C", "D" };
                AvailableCosts = new ObservableCollection<string>();
            }
    
            // Create the OnPropertyChanged method to raise the event
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
