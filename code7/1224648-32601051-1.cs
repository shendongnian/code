    <DataGrid x:Name="SignalGridWithTemplates" AutoGenerateColumns="False" SelectedIndex="0" ItemsSource="{Binding}">
                <DataGrid.Columns>
    
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                    <DataGridTextColumn Header="Value" Binding="{Binding Value}"/>
                    <DataGridTemplateColumn Header="RawValues">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <ComboBox ItemsSource="{Binding RawValues}">
                                        <ComboBox.ItemTemplate>
                                            <DataTemplate>
                                                <StackPanel Orientation="Horizontal">
                                                    <TextBlock Text="{Binding Name}" Background="AliceBlue"/>
                                                    <TextBlock Text=" | "/>
                                                    <TextBlock Text="{Binding Value}" Background="Azure"/>
                                                </StackPanel>
                                            </DataTemplate>
                                        </ComboBox.ItemTemplate>
                                    </ComboBox>
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
    
                </DataGrid.Columns>
            </DataGrid>
