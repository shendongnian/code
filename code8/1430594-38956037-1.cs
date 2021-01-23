    public partial class PersonView : UserControl 
    {
      private readonly Person Model;
    
      public PersonView()  
     {
        //Components initialization, etc. etc...
        this.Model = new Person(); 
        this.DataContext = this.Model;  // Here we are binding the model with our view.
     }
     private void SaveInfoButton_Click(object sender, RoutedEventArgs e)
    {
          MessageBox.Show(this.Model.PersonName); // this will print the value of your textbox.
        }
        
            }
