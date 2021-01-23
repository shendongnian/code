    <GridView ItemsSource="{Binding MyList}">
                        <Gridview.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding foo}"/>
                            </DataTemplate>
                        </GridView.ItemTemplate>
                        <GridView.ItemsPanel>
                            <ItemsPanelTemplate>
                                <WrapGrid MaximumRowsOrColumns="4" Orientation="Horizontal"/>
                            </ItemsPanelTemplate>
                        </GridView.ItemsPanel>
                    </GridView>
