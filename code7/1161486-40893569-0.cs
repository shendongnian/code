    <ListView ItemsSource="{Binding Gastos}" HasUnevenRows="True" SeparatorVisibility="None">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell >
                    <Grid Padding="5">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>
                        <Label Text="{Binding Id}" VerticalOptions="Start"/>
                        <Label Grid.Column="1" Text="{Binding Descripcion}" LineBreakMode="WordWrap"/>
                    </Grid>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
