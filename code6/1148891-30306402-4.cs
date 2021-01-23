    <Window.DataContext>
        <viewModel:MainViewModel />
    </Window.DataContext>
    <StackPanel>
        <DataGrid ItemsSource="{Binding Items}" 
                  SelectedItem="{Binding SelectedItem}" 
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Column" Binding="{Binding}" />
            </DataGrid.Columns>
        </DataGrid>
        <DataGrid ItemsSource="{Binding SelectedItem}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Column" Binding="{Binding}" />
            </DataGrid.Columns>
        </DataGrid>
    </StackPanel>
