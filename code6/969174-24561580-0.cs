    <TextBlock Text="Test"
                Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, 
                                                         AncestorType=Window}}">
        <TextBlock.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Test Me"
                          Command="{Binding PlacementTarget.Tag.TestCommand, 
                                   RelativeSource={RelativeSource Mode=FindAncestor, 
                                                      AncestorType=ContextMenu}}"/>
            </ContextMenu>
        </TextBlock.ContextMenu>
    </TextBlock>
