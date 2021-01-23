    <Button Content="Left ContextMenu test" IsHitTestVisible="{Binding ElementName=cm, Path=IsOpen, Mode=OneWay, Converter={StaticResource BoolInverter}}">
        <i:Interaction.Behaviors>
            <extensions:LeftClickContextMenuButtonBehavior />
        </i:Interaction.Behaviors>
        <Button.ContextMenu>
            <ContextMenu x:Name="cm">
                <MenuItem Header="Item A" />
                <MenuItem Header="Item B" /> 
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
