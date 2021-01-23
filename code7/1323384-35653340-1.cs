    <DockPanel>
        <GroupBox Header="Filter" DockPanel.Dock="Top">
            <StackPanel Orientation="Horizontal">
            <Label Content="Label 1" />
            <Label Content="Label 2" />
            </StackPanel>
        </GroupBox>
        <Menu DockPanel.Dock="Bottom">
            <MenuItem Header="Menu 1">
                
            </MenuItem>
            <MenuItem Header="Menu 2">
            </MenuItem>
        </Menu>
        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Header1" Width="*" />
                <DataGridTextColumn Header="Header2" Width="*" />
                <DataGridTextColumn Header="Header3" Width="*" />
                <DataGridTextColumn Header="Header4" Width="*" />
            </DataGrid.Columns>
        </DataGrid>
    </DockPanel>
