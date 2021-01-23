    <ComboBox ItemsSource="{Binding ListOfProperties}" SelectedValuePath="Id">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid Background="{Binding ColorName, Converter={StaticResource StringToBrushConverter}">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <Image Source="{Binding ImageUrl}"/> // "ms-appx:///Assets/image.png" for example
                    <TextBlock Grid.Column="1" Text="{Binding Text}"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
