    <ResourceDictionary
        x:Class="WPF.Styles"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfApplication1">
        <DataTemplate x:Key="ContactItemTemplate" DataType="local:Person">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="Auto" />
                </Grid.ColumnDefinitions>
                <TextBlock
                    Grid.Column="0"
                    Foreground="Black"
                    Background="Yellow"
                    Padding="5,10"
                    Margin="4,3"
                    Text="{Binding Name}"
                    >
                    <TextBlock.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="Edit!" Click="btn_EditContact_Click"/>
                            <MenuItem Header="Delete!" Click="btn_DeleteContact_Click"/>
                            <MenuItem Header="View!" Click="btn_EditContact_Click"/>
                        </ContextMenu>
                    </TextBlock.ContextMenu>
                </TextBlock>
                <Button
                    Grid.Column="1"
                    Content="Edit"
                    Click="btn_EditContact_Click"/>
            </Grid>
        </DataTemplate>
    </ResourceDictionary>
