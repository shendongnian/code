    <Setter Property="ContextMenu">
                        <Setter.Value>
                            <ContextMenu>
                                <MenuItem Header="Delete" >
                                    <MenuItem.Style>
                                        <Style TargetType="MenuItem">
                                            <EventSetter Event="Click" Handler="Delete_OnClick"/>
                                        </Style>
                                    </MenuItem.Style>
                                </MenuItem>
                            </ContextMenu>
                        </Setter.Value>
                    </Setter>
