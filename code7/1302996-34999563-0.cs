    public static class Config
    {
        public class Material
        {
            public Material(float value, int cost){
                Value = value;
                Cost = cost;
            }
    
            public float Value {get; private set;}
            public int Cost {get; private set;}
    
            public Material GetFor(MaterialQuality quality){
                 switch(quality){
                     case MaterialQuality.Low: return new Material(0.1f, 10);
                     case MaterialQuality.Medium: return new Material(0.2f, 20);
                     case MaterialQuality.High: return new Material(0.2f, 40);
                 }
                 throw new Exception("Unknown material quality " + quality);
            }
                   
        }
    }
