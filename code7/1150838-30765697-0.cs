    public class ViewModel
    {
        public MyItem SelectedItem { get; set; } //fire prop changed
    }
    <GridView SelectedItem="{x:Bind SelectedItem, mode=Twoway}"/>
    <TextBlock Text="{x:Bind ViewModel.SelectedItem.bezeich}"
