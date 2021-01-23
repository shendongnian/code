    public struct CultureContext : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        public CultureContext(CultureInfo culture)
        {
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _originalCulture;
        }
    }
