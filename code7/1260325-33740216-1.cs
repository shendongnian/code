    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Transactions}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="TransaccionId" Binding="{Binding TransaccionId}" />
            <DataGridTextColumn Header="Fecha" Binding="{Binding Fecha}" />
            <DataGridTextColumn Header="Descripcion" Binding="{Binding Descripcion}" />
            <DataGridTemplateColumn Header="Details">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ListBox ItemsSource="{Binding TransactionDetails}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
