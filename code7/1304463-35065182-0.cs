    public abstract class Theme
    {
        public Dictionary<string, Color> Colours { get; set; } = new Dictionary<string, Color>();
        protected void DictionaryThemes(Type type)
        {
            var properties = type.GetRuntimeProperties();
            foreach (PropertyInfo propInfo in properties)
            {
                if (propInfo.PropertyType == typeof(Color))
                {
                    var key = propInfo.Name;
                    var value = propInfo.GetValue(this);
                    Colours.Add(key, (Color)value); 
                }
            }
        }
        public abstract Color TitleColour { get; }
    }
