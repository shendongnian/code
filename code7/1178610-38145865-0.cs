    <ContextMenu ItemsSource="{Binding Path=MenuItems}" UsesItemContainerTemplate="True">
                  <ContextMenu.Resources>
                    <ResourceDictionary>
                      <ItemContainerTemplate DataType="{x:Type ViewModel:MenuItemViewModel }">
                        <MenuItem Header="{Binding Path=Header}" Command="{Binding Path=Command}" UsesItemContainerTemplate="True">
                          <MenuItem.Icon>
                            <Image Source="{Binding Path=ImageSource}"/>
                          </MenuItem.Icon>
                        </MenuItem>
                      </ItemContainerTemplate>
                      <ItemContainerTemplate DataType="{x:Type ViewModel:SeparatorViewModel}">
                        <Separator >
                          <Separator.Style>
                            <Style TargetType="{x:Type Separator}" BasedOn="{StaticResource ResourceKey={x:Static MenuItem.SeparatorStyleKey}}"/>
                          </Separator.Style>
                        </Separator>
                      </ItemContainerTemplate>
                    </ResourceDictionary>
                  </ContextMenu.Resources>
                </ContextMenu>
