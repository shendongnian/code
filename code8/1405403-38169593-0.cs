    <DataGrid   ItemsSource="{Binding ItemsList}"
                AutoGenerateColumns="False" IsReadOnly="True"
                SelectedItem="{Binding SelectedItem}"
                >
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding ID.newValue}" />
            <DataGridTextColumn Header="Name" Binding="{Binding Name.newValue}" />
            <DataGridTextColumn Header="Gender" Binding="{Binding Gender.newValue}" />
        </DataGrid.Columns>
        <DataGrid.RowDetailsTemplate>
            <DataTemplate>
                <DataGrid ItemsSource="{Binding Path=DataContext.SelectedItemCollection, 
                                        RelativeSource={RelativeSource AncestorType=DataGrid}}"     
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
