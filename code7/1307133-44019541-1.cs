    public class CultureAwareBinding : System.Windows.Data.Binding
    {
        public CultureAwareBinding()
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }
    }
