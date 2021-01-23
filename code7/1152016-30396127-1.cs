    public class FoodNeed : BaseNeeds
    {
        public Dictionary<Type, float> consumptionlist = new Dictionary<Type, float>();
    
        public FoodNeed()
        {
            consumptionlist.Add (typeof(Meat), 0.3f);
        }
    }
