    public class TransportationCostCalculator
    {
        Dictionary<string, int> multiplierDictionary;
        TransportationCostCalculator () 
        {
             var multiplierDictionary= new Dictionary<string, int> (); 
             dictionary.Add ("Bicycle", 1);
             dictionary.Add ("Bus", 2);
             ....
        }
        public decimal CostOfTravel(string transportMethod)
        {
             return  (decimal) (multiplierDictionary[transportMethod] * DistanceToDestination);       
        }
