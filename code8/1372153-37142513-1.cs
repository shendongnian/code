     public class MyListView : ListView
        {
           
    
            public MyListView()
            {
                this.ItemTapped += this.OnItemTapped;
                
            }
    
            public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<MyListView, ICommand>(x => x.ItemClickCommand, null);
            
            public ICommand ItemClickCommand {
                get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
                set { this.SetValue(ItemClickCommandProperty, value); }
            }
    
    
            private void OnItemTapped(object sender, ItemTappedEventArgs e) {
                if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e)) {
                    this.ItemClickCommand.Execute(e.Item);
                    this.SelectedItem = null;
                }
            }
        
        }
