    <ListView ItemSource="{Binding ParentSource}">
                                      <ListView.ItemTemplate >
                                        <DataTemplate>
                                          <ViewCell>
                                            <ViewCell.ContextActions>
                                              <MenuItem Text="Delete" />
                                            </ViewCell.ContextActions>
                                            <ViewCell.View>
                                              <Label Text="{Binding Prop1}"/>
                                              <ListView ItemSource="{Binding ChildSource}">
                                                <ListView.ItemTemplate >
                                                  <DataTemplate>
                                                    <ViewCell>
                                                      <ViewCell.View>
                                                        <Grid x:Name="RootGrid"
                                                              BindingContext="{Binding}">
                                                          <Label Text="{Binding BindingContext.ChildProp1, Source={x:Reference RootGrid}}"/>
                                                        </Grid>
                                                      </ViewCell.View>
                                                    </ViewCell>
                                                  </DataTemplate>
                                                </ListView.ItemTemplate>
                                              </ListView>
                                            </ViewCell.View>
                                          </ViewCell>
                                        </DataTemplate>
                                      </ListView.ItemTemplate>
                                    </ListView>
