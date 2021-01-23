    class FlipViewDemo
    {
        private List<object> mData;
        public IEnumerable<object> Data
        {
            get { return mData; }
        }
        public FlipViewDemo()
        {
            mData = new List<object>();
            mData.Add("Test String");
            for (int i = 0; i < 18; ++i)
            {
                AddData("Test Data " + i.ToString());
            }
        }
        private void AddData(object data)
        {
            List<object> current = mData.LastOrDefault() as List<object>;
            if (current == null || current.Count == 3)
            {
                current = new List<object>();
                mData.Add(current);
            }
            current.Add(data);
        }
    }
    class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate ListTemplate { get; set; }
        public DataTemplate ObjectTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is List<object>) return ListTemplate;
            return ObjectTemplate;
        }
    }
