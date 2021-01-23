    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Foo item;
        public MyViewModel()
        {
            //Item = new Foo();
            //Item.Item = "Bar";
        }
       
        public Foo Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
                RaisePropertyChanged("Item");
            }
        }
        public string Bar
        {
            get
            {
                if(Item == null)
                {
                    return "Item is null. OMG!";
                }
                else
                {
                    return Item.Item;
                }
            }
            set
            {
                Item.Item = value;
                RaisePropertyChanged("Bar");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    <TextBox Width="200" Height="30" Text="{Binding Bar}" TextAlignment="Center"/>
