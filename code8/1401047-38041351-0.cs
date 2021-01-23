    public class PriceGenerator {
    
            private PriceGenerator() {
                this.Prices = new ObservableCollection<Price>();
                this.Generate();
                
            }
    
            void Generate() {
                //Generate Objects here
    
                this.Prices.Add(generatedPrice);
            }
    
            public ObservableCollection<Price> Prices {
                get;
            }
    
    
            private static PriceGenerator _instance;
            public static PriceGenerator Instance => _instance ?? (_instance = new PriceGenerator());
    
        }
