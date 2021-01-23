    <ListView.ItemContainerStyle>
    <Style TargetType="{x:Type ListViewItem}">
        <Setter Property="Tag" Value="{Binding Path=DataContext, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListView}}"/>
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu cal:Action.TargetWithoutContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}">
                   <MenuItem Header="Properties"  cal:Message.Attach="ShowProperties($dataContext)" >
                    <MenuItem.Icon>
                        <Image Source="../PropertyIcon.png" />
                    </MenuItem.Icon>
                </MenuItem>
                </ContextMenu>
            </Setter.Value>
        </Setter>
    </Style>
    </ListView.ItemContainerStyle>
