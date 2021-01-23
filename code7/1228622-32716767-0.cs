        <TabControl  x:Name="tabControl"  TabStripPlacement="Left" ItemsSource="{Binding Path=TableCollection}">
                <TabControl.ItemTemplate>
                    <DataTemplate DataType="{x:Type YourTableType}">
                      <TabItem Header={Binding TableName}>
                        <DataGrid ItemsSource="{Binding Rows}" AutoGenerateColumns="False">
                            <DataGrid.Columns>
                                <DataGridTextColumn Header="Tag" Binding="{Binding Tag}" />
                                <DataGridTextColumn Header="Description" Binding="{Binding Description}" />
                                <DataGridTextColumn Header="Value" Binding="{Binding Value}" />
                            </DataGrid.Columns>
                        </DataGrid>
                      </TabItem>
                    </DataTemplate>
                </TabControl.ItemTemplate>
            </TabControl>
