    public class PickerPage : ContentPage
    {
        ListView listView { get; set; }
        public PickerPage (OptionListItem [] items)
        {
            listView = new ListView () ;
            Content = new StackLayout {
                Children = { listView }
            };
            var cell  = new DataTemplate(() => {return new PickerListCell(this); });            
            cell.SetBinding (PickerListCell.TextProperty, "Caption");
            cell.SetBinding (PickerListCell.CommandParameterProperty, "Value");
            listView.ItemTemplate = cell;
            listView.ItemsSource = items;
        }
      
       void OnEditAction (object sender, EventArgs e)
       {
            var cell = (sender as Xamarin.Forms.MenuItem).BindingContext as PickerListCell;
            await Navigation.PushAsync (new RecordEditPage (recId), true);
       }
    }
