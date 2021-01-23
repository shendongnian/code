    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <ComboBox x:Name="ComboBoxWarehouses">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal" Width="Auto" Height="Auto">
                            <TextBlock Text="{Binding Name}"/>
                        </StackPanel>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
        </Grid>
        public MainPage()
        {
            this.InitializeComponent();
            var items = new ObservableCollection<Warehouse>();
            var item = new Warehouse() {Name = "selected"};
            items.Add(new Warehouse() { Name = "not selected"});
            items.Add(item);
            items.Add(new Warehouse() { Name = "Another Not Selected"});
            ComboBoxWarehouses.ItemsSource = items;
            ComboBoxWarehouses.SelectedItem = item;
        }
