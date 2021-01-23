    <ComboBox ItemSource="{Binding LogTimeSpan}"
              Grid.Row="15"
              Grid.Column="1"
              Grid.ColumnSpan="2">
      <ComboBox.Resources>
        <ns:TimeSpanConverter x:Key="TimeSpanConverter" />
      </ComboBox.Resources>
      <ComboBox.ItemTemplate>
        <DataTemplate>
          <TextBlock Text="{Binding Path=., Mode=OneTime, Converter={StaticResource TimeSpanConverter}" />
        </DataTemplate>
      </ComboBox.ItemTemplate>
    </ComboBox>
