    <DataGrid AutoGenerateColumns="False" HeadersVisibility="Column" IsReadOnly="True" Name="f_Grid" SelectionUnit="FullRow">
      <DataGrid.Columns> 
        <DataGridTemplateColumn Width="auto" SortMemberPath="IsUse" Header="ButtonColumn">
          <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
              <Button Click="ClickEvent" />
            </DataTemplate>
          </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>        
      </DataGrid.Columns>
    </DataGrid>
