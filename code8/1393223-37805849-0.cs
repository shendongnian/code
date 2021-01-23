    <Window.Resources>
        <local:IndexToDescriptionConverter x:Key="IndexToDescriptionConverter" />
    </Window.Resources> 
    ....
        <TabControl x:Name="MainTabs" Grid.Row="2" ItemsSource="{Binding Path=TabModels}" DisplayMemberPath="TabCaption">
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <DataGrid ItemsSource="{Binding Path=TabDataTable}" AutoGenerateColumns="True" IsReadOnly="True" SelectionUnit="CellOrRowHeader" >
                        <DataGrid.Resources>
                            <Style TargetType="{x:Type DataGridColumnHeader}">
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="ToolTip">
                                            <Setter.Value>
                                                <MultiBinding Converter="{StaticResource IndexToDescriptionConverter}">
                                                    <Binding Path="Column.DisplayIndex" 
                             RelativeSource="{RelativeSource Self}"/>
                                                    <Binding Path="DataContext.ColumnDescriptions" 
                             RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}"/>
                                                </MultiBinding>
                                            </Setter.Value>
                                        </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </DataGrid.Resources>
                    </DataGrid>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
