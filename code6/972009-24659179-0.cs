    public class ViewModel : INotifyPropertyChanged
    {
        ...
        public Model MyModel { get; set; }
        public void methodToBeCalledWhenPropertyIsSet() { }
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel()
        {
            MyModel.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Property")
            {
                 methodToBeCalledWhenPropertyIsSet();
            }
        }
    }
