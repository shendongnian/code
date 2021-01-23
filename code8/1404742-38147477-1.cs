    <TextBlock Text="{Binding FriendlyName, Mode=OneWay}" Tag="{Binding ElementName=MainGrid}" >
        <TextBlock.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Start" 
                          Command="{Binding Path=PlacementTarget.Tag.StartClientCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                          CommandParameter="{Binding Path=PlacementTarget, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                <MenuItem Header="Stop" 
                          Command="{Binding  Path=PlacementTarget.Tag.StopClientCommand , RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                          CommandParameter="{Binding Path=PlacementTarget, RelativeSource={RelativeSource AncestorType=ContextMenu}}"  />
                <MenuItem Header="Calibrate" 
                          Command="{Binding  Path=PlacementTarget.Tag.CalibrateClientCommand, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                          CommandParameter="{Binding Path=PlacementTarget, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
            </ContextMenu>
        </TextBlock.ContextMenu>
    </TextBlock>
