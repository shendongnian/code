      public class Temperature {
        private _Celsius
    
        public double Celsius {
          get {
            return _Celsius;
          }
          set {
            // Simplest: no validation (e.g. -500 degree is a evident error)
            _Celsius = value;
          } 
        }
    
        public double Kelvin {
          get { 
            return Celsius + 273.15;
          }  
          set {
            Celsius = value - 273.15;
          } 
        }
    
        public double Fahrenheit {
          get { 
            return Celsius * 9 / 5 + 32;
          }  
          set {
            Celsius = (value - 32) * 5 / 9;
          } 
        }
      } 
