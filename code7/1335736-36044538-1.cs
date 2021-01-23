    <TextBlock DockPanel.Dock="Left"
                               Text="{Binding InfoValue}"
                               TextAlignment="Left"
                               Tag="{Binding RelativeSource={RelativeSource AncestorType={x:Type Window}}}">
                        <TextBlock.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="{Binding Path=Parent.DataContext.InfoValue, RelativeSource={RelativeSource Self}}"
                                          IsEnabled="False" />
                                <MenuItem Header="Add child"
                                          Command="{Binding Path=Parent.PlacementTarget.Tag.AddChildCmd, RelativeSource={RelativeSource Self}}" />
                            </ContextMenu>
                        </TextBlock.ContextMenu>
                    </TextBlock>
