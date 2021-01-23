    <DataGrid ItemsSource="{Binding}" Name="grdSignal" Grid.Row="1" CanUserAddRows="False" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="            Signal Name" Binding="{Binding Name}" Width="150"/>
            <DataGridTemplateColumn Header="   Physical Value " Width="100">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox  ItemsSource="{Binding rawValue, Mode=OneWay}" SelectedItem="{Binding SelectedRaValue, Mode=TwoWay,  UpdateSourceTrigger=PropertyChanged}"  DisplayMemberPath="name" Name="cmbVal"
    			                 Visibility="{Binding Path=rawValue.Count, Converter={StaticResource ComboBoxItemCountToEnabledConverter}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="    Value " Width="100">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding ComboValue}"  />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
