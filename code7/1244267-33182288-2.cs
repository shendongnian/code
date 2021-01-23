    class ViewModel : DependencyObject
    {
        public static readonly DependencyProperty FamiliesProperty =
            DependencyProperty.Register("Families", typeof(ObservableCollection<Families>),
            typeof(ViewModel), new PropertyMetadata(new ObservableCollection<Families>()));
        public ObservableCollection<Family> Families
        {
            get { return (ObservableCollection<Family>)GetValue(FamiliesProperty); }
            set { SetValue(FamiliesProperty, value); }
        }
    }
