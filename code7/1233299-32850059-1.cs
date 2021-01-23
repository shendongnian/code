    public class ListContainsConverter : DependencyObject, IValueConverter
    {
        public object Convert(...)
        {
            //More generic version left as an exercise
            int testValue = int.Parse(parameter.ToString());
            return collection.Contains(testValue);
        }
    
        public object ConvertBack(...)
        {
            bool checked = (bool)value;
            int testValue = int.Parse(parameter.ToString());
           
            if (checked)
               Collection.Add(testValue);
            else
               Collection.Remove(testValue)
        }
        public IList<int> Collection
        {
           get { return (IList<int>)GetValue(CollectionProperty); }
           set { SetValue(CollectionProperty, value); }
        }
        public static readonly DependencyProperty CollectionProperty =
        DependencyProperty.Register("Collection", typeof(IList<int>), typeof(ListContainsConverter), null);
    }
