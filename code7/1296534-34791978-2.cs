        // My ClassName with method Hours()
        public class ClassName
        {
    
            // My ClassName with method Hours()
            public static decimal Hours()
            {
                var citiesDistance = new Dictionary<string, int> 
                { 
                    {"Place1",10},
                    {"Place2",20},
                    {"Place3",30},
                };
    
                var cities = "Place1";
                var length = citiesDistance[cities];
    
                decimal speed = 100;
    
                decimal hours = length / speed;
    
                return hours;
            }
        }
