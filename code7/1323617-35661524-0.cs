    namespace Weather
    {
        using System;
    
        public class CeliusToFahrentheit
        {
    
            public int? Celius { get; set; }
            public int? Fahrentheit
            {
                get
                {
                    int? returnValue = null;
    
                    if (this.Celius.HasValue)
                    {
                        returnValue = ((this.Celius * 9) / 5) + 32;
                    }
    
                    return returnValue;
                }
            }
    
            public override string ToString()
            {
                string returnValue = string.Empty;
    
                if (this.Celius.HasValue)
                {
                    returnValue = string.Format("{0} degrees celsius is {1} fahrenheit degrees.", this.Celius.Value, this.Fahrentheit.Value);
                }
                return returnValue;
            }
        }
    }
