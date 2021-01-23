    APIKarhoBookingProperties objbooking = new APIKarhoBookingProperties();
      objbooking.currency = "USD";
      objbooking.price_components = new List<PriceComponent>() {
    new PriceComponent{component_name = "abc", value = 1.0, ...},
    new PriceComponent{component_name = "xyz", value = 2.9, ...},
    new PriceComponent{component_name = "def", value = 1120, ...},
    ...
    }; 
      class APIKarhoBookingProperties
      {
        public string currency { get; set; }
        public List<PriceComponent> price_components { get; set; }
      }
      public class PriceComponent
      {
            public string component_name { get; set; }
            public double value { get; set; }
            public string description { get; set; }
            public string currency { get; set; }
      }
