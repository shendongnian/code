    public struct MaterialQualityInfo
    {
        public MaterialQualityInfo( float value, int cost )
        {
            Value = value;
            Cost = cost;
        }
        public float Value { get; private set; }
        public int Cost { get; private set; }
    }
    public static class Config
    {
        public static class MaterialQuality
        {
            public static MaterialQualityInfo Low
            {
                get { return new MaterialQualityInfo( 0.1f, 10 ); }
            }
            public static MaterialQualityInfo Medium
            {
                get { return new MaterialQualityInfo( 0.2f, 20 ); }
            }
            public static MaterialQualityInfo High
            {
                get { return new MaterialQualityInfo( 0.2f, 40 ); }
            }
        }
    }
    public class Material
    {
        private int Cost;
        private float Value;
        Material( MaterialQualityInfo quality )
        {
            Cost = quality.Cost;
            Value = quality.Value;
        }
    }
