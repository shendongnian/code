    <Style TargetType="{x:Type DataGridCell}">
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu>
                    <MenuItem Header="Copy" Command="{Binding CopyToClipBoardCommand, Mode=OneWay}"
                                CommandParameter="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}, Path=PlacementTarget}">
                        <MenuItem.DataContext>
                            <cust:CopytoContext />
                        </MenuItem.DataContext>
                    </MenuItem>
                </ContextMenu>
            </Setter.Value>
        </Setter>
    </Style>
