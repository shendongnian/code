    <Controls:MetroWindow.Resources>
        <DataTemplate x:Key="DataTemplate1">
                <Button  Click="Button_Click">
                    <Button.Template>
                        <ControlTemplate TargetType="Button">
                            <Image  Source="Icon.ico" />
                        </ControlTemplate>
                    </Button.Template>
                <Button.ContextMenu>
                    <ContextMenu>
                        <Menu>
                            <MenuItem Header="Nonsense"/>
                        </Menu>
                    </ContextMenu>
                </Button.ContextMenu>
            </Button>                   
        </DataTemplate>
    </Controls:MetroWindow.Resources>
