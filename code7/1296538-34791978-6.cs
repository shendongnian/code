        // My ClassName with method Hours()
        public class ClassName
        {
    
            // My ClassName with method Hours()
        public static decimal Hours(string place)
        {
            var citiesDistance = new Dictionary<string, int> 
            { 
                {"Place1",10},
                {"Place2",20},
                {"Place3",30},
            };
            
            var length = citiesDistance[place];
    
                decimal speed = 100;
    
                decimal hours = length / speed;
    
                return hours;
            }
        }
