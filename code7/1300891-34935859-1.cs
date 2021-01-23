    <TabControl Grid.Column="1" ItemsSource="{Binding Items}" SelectedItem="{Binding ActiveItem}">
                    <TabControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Table.TableName}"    />
                        </DataTemplate>
                    </TabControl.ItemTemplate>
                    <TabControl.ContentTemplate>
                        <DataTemplate DataType="{x:Type viewModels:QueryViewModel}">
                            <local:QueryView />
                        </DataTemplate>
                    </TabControl.ContentTemplate>
                </TabControl>
