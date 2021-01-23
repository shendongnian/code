    public enum MaterialQuality
    {
        Low, Medium, High
    }
    public class Material
    {
        private int Cost;
        private float Value;
        private readonly Dictionary<MaterialQuality, Tuple<int, float>> storageMap = new Dictionary<MaterialQuality, Tuple<int, float>>
        {
            { MaterialQuality.Low, Tuple.Create(10, 0.1f)},
            { MaterialQuality.Low, Tuple.Create(20, 0.2f)},
            { MaterialQuality.Low, Tuple.Create(40, 0.2f)},
        }; 
        public Material(MaterialQuality quality)
        {
            Cost = storageMap[quality].Item1;
            Value = storageMap[quality].Item2;
        }
    }
