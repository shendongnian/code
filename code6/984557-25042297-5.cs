    <DataGrid DockPanel.Dock="Top"
              ItemsSource="{Binding CollectionBindingOne}"
              AutoGenerateColumns="False">
        <DataGrid.Resources>
            <helper:BindingProxy x:Key="proxy"
                                 Data="{Binding }" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="One"
                                Binding="{Binding PropOne}" />
            <DataGridTextColumn Header="Two"
                                Binding="{Binding PropTwo}" />
            <DataGridComboBoxColumn Header="Three" 
                                    ItemsSource="{Binding Data.CollectionBindingTwo,
                                                  Source={StaticResource proxy}}" />
    </DataGrid>
