     public class ListIte
     {
        public String Name { get; set; }        
     }
     //...
     private ObservableCollection<ListIte> _items =new ObservableCollection<ListIte>()
        {
            new ListIte()
            {
                Name = "Name"
            }, new ListIte()
            {
                Name = "Element"
            }, new ListIte()
            {
                Name = "Save"
            }, new ListIte()
            {
                Name = "Test"
            },
        } ;
        public ObservableCollection<ListIte> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items == value)
                {
                    return;
                }
                _items = value;
                OnPropertyChanged();
            }
        }
       
        private String _addedText ="" ;
        public String AddedText
        {
            get
            {
                return _addedText;
            }
            set
            {
                if (_addedText == value)
                {
                    return;
                }
                if (Items.FirstOrDefault(x => x.Name.StartsWith(value))==null)
                {   
                    //to get the Editable TextBox from the combobox
                    var textBox = cbx.Template.FindName("PART_EditableTextBox", cbx) as TextBox;
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                    textBox.CaretIndex = textBox.Text.Length;
                    return;
                }
                _addedText = value;
                OnPropertyChanged();
            }
        }
