     <Button Tag="{Binding Path=DataContext, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}">
                                        View
                                        <!--  Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path=DataContext.  -->
                                        <Button.ContextMenu>
                                            <ContextMenu FontSize="11">
                                                <MenuItem Command="{Binding Path=PlacementTarget.Tag.TestCommand,
                                                                            RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}}}"
                                                          CommandParameter="{Binding FileId}"
                                                          Header="Splitter Errors" />
                                            </ContextMenu>
                                        </Button.ContextMenu>
                                    </Button>
