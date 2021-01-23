    <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False">
        <DataGrid.Resources>
            <local:ToCollectionConverter x:Key="ToCollectionConverter" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding ID.newValue}" />
            <DataGridTextColumn Header="Name" Binding="{Binding Name.newValue}" />
            <DataGridTextColumn Header="Gender" Binding="{Binding Gender.newValue}" />
        </DataGrid.Columns>
        <DataGrid.RowDetailsTemplate>
            <DataTemplate>
                <DataGrid ItemsSource="{Binding Converter={StaticResource ToCollectionConverter}}"     
                          AutoGenerateColumns="False"
                          HeadersVisibility="None"
                          >
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="ID" Binding="{Binding ID.oldValue}" />
                        <DataGridTextColumn Header="Name" Binding="{Binding Name.oldValue}" />
                        <DataGridTextColumn Header="Gender" Binding="{Binding Gender.oldValue}" />
                    </DataGrid.Columns>
                </DataGrid>
            </DataTemplate>
        </DataGrid.RowDetailsTemplate>
    </DataGrid>
