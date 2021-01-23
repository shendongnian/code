    public class BreakfastProviderFactory
    {
        private readonly CornFlakeProvider provider1;
        private readonly MuesliProvider provider2;
        private readonly ToastProvider provider3;
        public BreakfastProviderFactory(CornFlakeProvider provider1,
            MuesliProvider provider2, ToastProvider provider3) {
        {
            this.provider1 = provider1;
            this.provider2 = provider2;
            this.provider3 = provider3;
        }
        public IBreakfastProvider GetBreakfastProvider(int id)
        {
            switch (id)
            {
                case 1: return this.provider1;
                case 2: return this.provider2;
                case 3: return this.provider3;
                default: throw new ApplicationException("Unknown provider id."); 
            }
        }
    }
