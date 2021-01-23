        public decimal CostOfTravel(string transportMethod)
        {
             var dictionary = new Dictionary<string, int> (); 
             dictionary.Add ("Bicycle", 1);
             dictionary.Add ("Bus", 2);
               ...
             return  (decimal) (dictionary[transportMethod] * DistanceToDestination);       
        }
