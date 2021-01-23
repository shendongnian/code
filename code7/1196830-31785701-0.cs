       <GridView x:Name="grdSelectShape" ScrollViewer.HorizontalScrollMode="Enabled" ScrollViewer.HorizontalScrollBarVisibility="Visible" ScrollViewer.IsHorizontalRailEnabled="True" SelectionChanged="grdSelectShape_SelectionChanged"  >
                                    <GridView.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <VirtualizingStackPanel Orientation="Horizontal" />
                                        </ItemsPanelTemplate>
                                    </GridView.ItemsPanel>
                                    <GridView.ItemTemplate>
                                        <DataTemplate>
                                            
                                                <Image Margin="5" Stretch="None"   Source="{Binding}" />
                                            
                                        </DataTemplate>
                                    </GridView.ItemTemplate>
                                </GridView>
