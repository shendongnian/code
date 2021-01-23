    <Button.ContextMenu>
                            <ContextMenu Opened="OnContextMenuOpened">                                
                                <MenuItem Header="Send2" Command="{Binding ElementName=Lst, Path=DataContext.SaveCommand}" />
                            </ContextMenu>
                        </Button.ContextMenu>
