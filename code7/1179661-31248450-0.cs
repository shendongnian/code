    public class DecoratedComboBox : ComboBox
    {
        public IList ItemsToShow
        {
            get { return (IList)GetValue(ItemsToShowProperty); }
            set { SetValue(ItemsToShowProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ItemsToShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsToShowProperty =
            DependencyProperty.Register("ItemsToShow", typeof(IList), typeof(DecoratedComboBox), new PropertyMetadata(null));
        static DecoratedComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DecoratedComboBox), new FrameworkPropertyMetadata(typeof(DecoratedComboBox)));
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            BuildList();
        }
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            BuildList();
        }
        private void BuildList()
        {
            //Clear the ItemsToShow List
            ItemsToShow.Clear();
            //TODO: Work out what to put in ItemsToShow
        }
    }
