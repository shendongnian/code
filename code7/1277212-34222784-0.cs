    <DataGrid Name="dataGrid">
       <DataGrid.Resources>
          <Style TargetType="DataGridColumnHeader">
             <EventSetter Event="Click" Handler="columnHeader_Click" />
          </Style>
       </DataGrid.Resources>
    </DataGrid>
    private void columnHeader_Click(object sender, RoutedEventArgs e)
    {
       var columnHeader = sender as DataGridColumnHeader;
       if (columnHeader != null)
       {
          SetSelectedCompany(11);     
       }
    }
