    <DataGrid x:Class="WindowsApplication1.Blah"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Height="300" Width="300">
        <DataGrid.Resources>
            <DataGridTemplateColumn Header="Delete" x:Key="DeleteColumn">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Content="X" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" />
            <DataGridTextColumn Header="Age" />
            <DataGridTextColumn Header="Class" />
            <DataGridTextColumn Header="School" />
        </DataGrid.Columns>
    </DataGrid>
