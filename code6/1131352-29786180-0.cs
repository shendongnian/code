        public enum VariationLevel
        {
            High,
            Medium,
            Low
        };
        public double[] HighVariancePrices =
        {
            100, 100, 100, 100, 100
        };
        public double[] MediumVariancePrices =
        {
            100, 100, 100, 100, 100
        };
        public double[] LowVariancePrices =
        {
            100, 100, 100, 100, 100
        };
        public void DaysEnd()
        {
            HighVariancePrices = HighVariancePrices.Select(price => GetVariation(price, VariationLevel.High)).ToArray();
            MediumVariancePrices = MediumVariancePrices.Select(price => GetVariation(price, VariationLevel.Medium)).ToArray();
            LowVariancePrices = LowVariancePrices.Select(price => GetVariation(price, VariationLevel.Low)).ToArray();
        }
        public double GetVariation(double value, VariationLevel variationLevel)
        {
            switch (variationLevel)
            {
                case VariationLevel.High:
                    return value + (value * (Random.NextDouble(0 - 0.5, 0.5)));
                case VariationLevel.Medium:
                    return value + (value * (Random.NextDouble(0 - 0.25, 0.25)));
                case VariationLevel.Low:
                    return value + (value * (Random.NextDouble(0 - 0.1, 0.5)));
            }
        }
