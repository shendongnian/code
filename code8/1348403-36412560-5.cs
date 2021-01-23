    public class TimesViewModel: INotifyPropertyChanged
    {
        //notifying property that is bound to ItemsSource in the first Combobox
        public List<string> MyFirstComboBoxItems{ get... }
    
        //This is the string that's bound to SelectedItem in the first ComboBox
        public string FirstComboBoxSelectedItem
        {
            get
            {
                return firstComboBoxSelectedItem;
            }
            set
            {
                //standard notify like all your other bound properties
                if (firstComboBoxSelectedItem!= value)
                {
                    firstComboBoxSelectedItem= value;
                    //when this changes, our selection has changed, so update the second list's ItemsSource
                    MySecondComboBoxItems = MyDictionaryOfSecondComboboxItems[SelectedKey];
                    NotifyPropertyChanged("SelectedKey");
                }
            }
        }
        //an "intermediatary" Property that's bound to the second Combobox, changes with the first's selection
        public List<string> MySecondComboBoxItems { get ... }
    }
