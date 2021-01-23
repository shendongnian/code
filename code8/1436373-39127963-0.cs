    <StackPanel>
            <StackPanel.ContextMenu>
                <ContextMenu x:Name="CMenu" StaysOpen="True" >
                                           <MenuItem Header="Item 1" StaysOpenOnClick="True"/>
                        <MenuItem Header="Item 2" StaysOpenOnClick="True">
                            <MenuItem Header="Sub item 1" StaysOpenOnClick="True"/>
                            <MenuItem Header="Sub item 2" StaysOpenOnClick="True"/>
                            <MenuItem Header="Sub item 3" StaysOpenOnClick="True"/>
                            <MenuItem Header="Sub item 4" StaysOpenOnClick="True"/>
                        </MenuItem>
                        <MenuItem Header="Item 3" StaysOpenOnClick="True"/>
                        <MenuItem Header="Item 4" StaysOpenOnClick="True"/>
                   
                </ContextMenu>
            </StackPanel.ContextMenu>
            <Label Content="ContextMenu Test" />
            <Button Content="ClickMe" Click="Button_Click" />
        </StackPanel>
