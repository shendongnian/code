    <Window x:Class="DataGridCellsBackground.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525"
        xmlns:local="clr-namespace:DataGridCellsBackground"        >
    <Grid>
        <Grid.Resources>
            <local:BoolToVis x:Key="BoolTovisibilityConverter"/>
        </Grid.Resources>
        <DataGrid SelectionUnit="Cell" 
                  ItemsSource="{Binding items}" 
                  AutoGenerateColumns="False">
            <DataGrid.Resources>
            </DataGrid.Resources>
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Name}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="Visible" Visibility="{Binding RelativeSource={RelativeSource AncestorType=DataGrid}, Path=DataContext.ButtonIsVisible, Converter={StaticResource BoolTovisibilityConverter}}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
