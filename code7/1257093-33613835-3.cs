    interface IWaveGenerator
    {
        IEnumerable<double> Generator(double timeSlice, double normalizationFactor = 1.0d);
    }
    [Export(typeof(IWaveGenerator))]
    class CombinedWaveGenerator : IWaveGenerator
    {
        private List<IWaveGenerator> constituentWaves;
        public IEnumerable<double> Generator(double timeSlice, double normalizationFactor = 1)
        {
            return constituentWaves.Select(wg => wg.Generator(timeSlice))
                                   .MultiZip(t => t.Sum() * normalizationFactor);
        }
        // ...
    }
