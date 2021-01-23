    [DataContract]
    public class Recipe
    {
   
        [XmlArray("IngredientsList", XmlArrayItem(typeof(IngredientMeasure), ElementName = "IngredientMeasure"))]
        public List<IngredientMeasure> IngredientList { get;  set; }
    
        // ... other properties 
    }
