    <Image Source="{Binding CurrentImage.Source, Mode=OneWay}" Grid.Row="0" Grid.Column="1" Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType= Window}}">
         <Image.ContextMenu>
                <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                      <MenuItem Header="Edit Image" Command="{Binding EditImageCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"></MenuItem>
                </ContextMenu>
         </Image.ContextMenu>
