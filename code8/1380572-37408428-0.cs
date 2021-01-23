    <Border.ContextMenu>
        <ContextMenu>
            <MenuItem IsEnabled="True" 
                      Command="{StaticResource MakeKeyCell}"
                      CommandTarget="{Binding Path=PlacementTarget, 
                                              RelativeSource={RelativeSource FindAncestor, 
                                              AncestorType={x:Type ContextMenu}}}" />
        </ContextMenu>
    </Border.ContextMenu>
