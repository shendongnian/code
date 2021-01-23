    public class Material
    {
       public float Value { get; private set; }
       public int Cost { get; private set; }
       public Material(float value, int cost)
       {
         Value = value;
         Cost = cost;
       }
       public static Material Low { get { return new Material(0.1f, 10); } }
       public static Material Medium { get { return new Material(0.2f, 20); } }
       public static Material High { get { return new Material(0.2f, 40); } }
    }
