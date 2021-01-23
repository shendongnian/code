     <DataGrid AutoGenerateColumns="False" SelectionUnit="Cell">
                <DataGrid.Resources>
                    <Style TargetType="DataGridRowHeader">
                        <EventSetter Event="Click" Handler="DataGridRowHeader_Click" />
                    </Style>
                </DataGrid.Resources>
                ....
     </DataGrid>
    private void DataGridRowHeader_Click(object sender, System.Windows.RoutedEventArgs e)
    {
                // This is when header is double clicked.
    }
