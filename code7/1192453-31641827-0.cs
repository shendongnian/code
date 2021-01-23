    class Name
    {
        public string Value { get; set; }
    
        public bool Enabled { get; set; }
    }
    public IEnumerable<Name> TheNames
    {
        get { return Names.Select(n => new Name {Value = n.Value, Enabled = EnabledNames[n.Key]}); }
    }
    <ListBox ItemsSource="{Binding Path=TheNames, Mode=OneWay}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox IsChecked="{Binding Path=Enabled}" />
                    <TextBlock Text="{Binding Value}"/>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
