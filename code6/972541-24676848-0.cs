    public class CollectionItem
    {
        public string Name { get; set; }
        public bool Exists { get; set; }
        public ObservableCollection<CollectionItem> CollectionOfSubItems { get; set; }
    }
...
    <MenuItem x:Name="AllItems" Header="What I Have">
        <MenuItem.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}">
                <Setter Property="Header" Value="{Binding Path=Name}" />
                <Setter Property="ItemsSource" Value="{Binding CollectionOfSubItems}" />
            </Style>
        </MenuItem.ItemContainerStyle>
    </MenuItem>
