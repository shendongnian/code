    public class TranlationExtension : MarkupExtension
    {
       public string Key { get; set; }
        public TranlationExtension(string key)
        {
            this.Key = key;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Binding binding = new Binding("TranslationDictionary[" + Key + "]");
            binding.Source = MyTranslations;
            return binding.ProvideValue(serviceProvider);
        }
    }
