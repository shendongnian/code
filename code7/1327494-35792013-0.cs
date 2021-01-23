                    <ContextMenu.ItemTemplate>
                    <DataTemplate>
                          <MenuItem Header="{Binding Text}" Command="{Binding Command}"/>
                            <MenuItem.Template>
                                <ControlTemplate>
                                        <ContentPresenter Content="{Binding Header,RelativeSource={RelativeSource TemplatedParent}}">
                                        </ContentPresenter>
                                </ControlTemplate>
                            </MenuItem.Template>
                            </MenuItem>
                    </DataTemplate>
                </ContextMenu.ItemTemplate>
