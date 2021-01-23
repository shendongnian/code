    <Window x:Class="MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525" x:Name="root">
        <Window.Resources>
                <CollectionViewSource x:Key="GroupedEntriesSource" Source="{Binding Entries}">
                    <CollectionViewSource.GroupDescriptions>
                        <PropertyGroupDescription PropertyName="Key"/>
                    </CollectionViewSource.GroupDescriptions>
                </CollectionViewSource>
        
                
                <Style x:Key="GroupContainerStyle" TargetType="{x:Type GroupItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type GroupItem}">
                                <Expander IsExpanded="True" Background="#414040" Tag="{Binding ElementName=root, Path=DataContext}">
                                    <Expander.ContextMenu>
                                        <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                            <MenuItem Header="Delete group" Command="{Binding DeleteGroupCommand}" CommandParameter="{TemplateBinding DataContext}" />
        
                                        </ContextMenu>
                                    </Expander.ContextMenu>
        
                                    <Expander.Header>
                                        <Grid>
                                            <TextBlock Text="{Binding Path=Items[0].Key.Name}"/>
                                        </Grid>
                                    </Expander.Header>
                                    <ItemsPresenter />
                                </Expander>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Window.Resources>
        
            <Grid>
                <DataGrid ItemsSource="{Binding Source={StaticResource GroupedEntriesSource}}" AutoGenerateColumns="False">
                    <DataGrid.GroupStyle>
                        <GroupStyle ContainerStyle="{StaticResource GroupContainerStyle}">
                            <GroupStyle.Panel>
                                <ItemsPanelTemplate>
                                    <DataGridRowsPresenter/>
                                </ItemsPanelTemplate>
                            </GroupStyle.Panel>
                        </GroupStyle>
                    </DataGrid.GroupStyle>
        
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="Name" Binding="{Binding Value.Name, Mode=OneWay}"/>
                        <DataGridTextColumn Header="Data" Binding="{Binding Value.Val, UpdateSourceTrigger=LostFocus}"/>
                    </DataGrid.Columns>
                </DataGrid>
            </Grid>
    </Window>
