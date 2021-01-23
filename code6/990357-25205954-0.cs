    <Button  Content="qwerty" Tag="{Binding DataContext,ElementName=Lst}" Command="{Binding ElementName=Lst, Path=DataContext.SaveCommand}"  >
                        <Button.ContextMenu>
                            <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">                                
                                <MenuItem Header="Send2" Command="{Binding SaveCommand}" />
                            </ContextMenu>
                        </Button.ContextMenu>    
                    </Button>
