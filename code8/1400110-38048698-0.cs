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
