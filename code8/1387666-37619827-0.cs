    public class MyType
    {
      public int ID {get; set;}
      public string Text {get; set;}
    }
    //CodeBehind
    public class CodeBehindClass
    {
      public ObservableCollection<MyType> MyCollection {get; set;} = new ObservableCollection();
    
      public MyType SelectedItem {get; set;}
      //Populate collection
      MyComboBox.ItemsSource = MyCollection;
      private void MyComboBox_SelectionChanged(object sender, selectionChangedEventArgs e)
      {
        SelectedItem = (MyType)MyComboBox.SelectedValue;
        //display string with SelectedItem.Text;
      }
    }
