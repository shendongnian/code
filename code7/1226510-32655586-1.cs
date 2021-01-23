    public class EnumSourceComboBox : ComboBox
    {
        private ObservableCollection<TaxAtSourceCategory> previousCollection;
        public static readonly DependencyProperty ExcludedItemsProperty =
            DependencyProperty.Register(
                "ExcludedItems",
                typeof(ObservableCollection<TaxAtSourceCategory>),
                typeof(EnumSourceComboBox),
                new PropertyMetadata(null));
        public ObservableCollection<TaxAtSourceCategory> ExcludedItems
        {
            get
            {
                return (ObservableCollection<TaxAtSourceCategory>)this.GetValue(EnumSourceComboBox.ExcludedItemsProperty);
            }
            set
            {
                this.SetValue(EnumSourceComboBox.ExcludedItemsProperty, value);
            }
        }
        public EnumSourceComboBox()
        {
            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(EnumSourceComboBox.ExcludedItemsProperty, typeof(EnumSourceComboBox));
            dpd.AddValueChanged(this, (o, e) =>
            {
                if (previousCollection != null)
                    previousCollection.CollectionChanged -= ExcludedItemsChanged;
                previousCollection = ExcludedItems;
                if (previousCollection != null)
                    previousCollection.CollectionChanged += ExcludedItemsChanged;
            });
            this.ExcludedItems = new ObservableCollection<TaxAtSourceCategory>();
        }
        void ExcludedItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Take into account change in the excluded items more seriously !
            MessageBox.Show("CollectionChanged to count " + ExcludedItems.Count);
        }
    }
