       <DataGrid ItemsSource="{Binding }" Name="dataGrid1" AutoGenerateColumns="False" 
                              ColumnHeaderHeight="50" >
                    <DataGrid.Resources>
    
                        <Style x:Key="DataGridColumnHeader" TargetType="{x:Type DataGridColumnHeader}">
                            <Setter Property="VerticalContentAlignment" Value="Center" />
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type DataGridColumnHeader}">
                                        <Grid>
                                            <ContentPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"
                                          VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                          HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" />
                                        </Grid>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
    
                    </DataGrid.Resources>
                    <DataGrid.Columns>
                            <DataGridTextColumn Binding="{Binding Country}" Header="Main1" Width="60" 
                                                HeaderStyle="{StaticResource DataGridColumnHeader}">
                            <DataGridTextColumn.HeaderTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Vertical">
                                        <TextBlock   Width="60"/>
    
                                        <DataGridColumnHeader Content="Nested1" Width="60"/>
                                    </StackPanel>
                                </DataTemplate>
                            </DataGridTextColumn.HeaderTemplate>
                        </DataGridTextColumn>
                        <DataGridTextColumn Binding="{Binding City}" Header="Nested2" Width="60"
                                                 HeaderStyle="{StaticResource DataGridColumnHeader}">
                            <DataGridTextColumn.HeaderTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Vertical">
                                        <TextBlock FontWeight="Bold" Text="Main1"/>
    
                                        <DataGridColumnHeader Content="Nested2" Width="60" />
                                    </StackPanel>
                                </DataTemplate>
                            </DataGridTextColumn.HeaderTemplate>
                        </DataGridTextColumn>
                        <DataGridTextColumn Binding="{Binding Street}" Header="Street" Width="60"
                                                 HeaderStyle="{StaticResource DataGridColumnHeader}">
                            <DataGridTextColumn.HeaderTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Vertical">
                                        <TextBlock />
    
                                        <DataGridColumnHeader Content="Nested3" Width="60"/>
                                    </StackPanel>
                                </DataTemplate>
                            </DataGridTextColumn.HeaderTemplate>
                        </DataGridTextColumn>
                    </DataGrid.Columns>
                </DataGrid>
