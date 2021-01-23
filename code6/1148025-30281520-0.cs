    <ComboBox ItemsSource="{Binding MyList}" SelectedValuePath="MyId">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid Background="{Binding MyColor, Converter={StaticResource StringToBrushConverter}">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <Image Source="ms-appx:///Assets/image.png"/>
                    <TextBlock Grid.Column="1" Text="{Binding MyText}"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
