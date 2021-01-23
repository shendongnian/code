    public class VisualLedPanel
    {
        private readonly Lazy<List<VisualLed>> _lazyVisualLeds = new Lazy<List<VisualLed>>(CreateVisualLeds);
        public VisualLed this[int x, int y]
        {
            get
            {
                var result = VisualLeds.FirstOrDefault(f => f.X == x && f.Y == y);
                return result;
            }
        }
		[JsonIgnore]
        public IEnumerable<VisualLed> VisualLeds
        {
            get
            {
                return _lazyVisualLeds.Value;
            }
        }
		
		[JsonProperty("VisualLeds")]
		VisualLed [] SerializableVisualLeds
		{
			get
			{
				return VisualLeds.ToArray();
					
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					if (_lazyVisualLeds.IsValueCreated)
						_lazyVisualLeds.Value.Clear();
				}
				else
				{
					_lazyVisualLeds.Value.Clear();
					_lazyVisualLeds.Value.AddRange(value);
				}
			}
		}
		
        private static List<VisualLed> CreateVisualLeds()
        {
            var result = new List<VisualLed>();
            for (var x = 0; x <= 7; x++)
            {
                for (var y = 0; y <= 7; y++)
                {
                    result.Add(new VisualLed(x, y));
                }
            }
            return result;
        }
    }
