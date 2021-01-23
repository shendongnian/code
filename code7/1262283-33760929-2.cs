    public struct CultureContext : IDisposable
    {
        public static readonly CultureInfo CommaCulture = new CultureInfo("en-us")
        {
            NumberFormat =
            {
                CurrencyDecimalSeparator = ",",
                NumberDecimalSeparator = ",",
                PercentDecimalSeparator = ","
            }
        };
        public static readonly CultureInfo PointCulture = new CultureInfo("en-us")
        {
            NumberFormat =
            {
                CurrencyDecimalSeparator = ".",
                NumberDecimalSeparator = ".",
                PercentDecimalSeparator = "."
            }
        };
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
        public static void UnderBoth(Action test)
        {
            using (new CultureContext(PointCulture))
            {
                test();
            }
            using (new CultureContext(CommaCulture))
            {
                test();
            }
        }
    }
