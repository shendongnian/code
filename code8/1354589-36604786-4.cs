    <Window x:Name="window"
            x:Class="Sandpit.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:Sandpit"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <DataGrid AutoGenerateColumns="False" x:Name="myGrid"  ItemsSource="{Binding Routes}" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Sequenza N°" />
                <DataGridTemplateColumn Header="Product">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Product}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding AvailableProducts}"
                                      SelectedValue="{Binding Product, UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Quality">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Quality}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding AvailableQuality}"
                                      SelectedValue="{Binding Quality, UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Quality">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Cost}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding AvailableCosts}"
                                      SelectedValue="{Binding Cost, UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Window>
