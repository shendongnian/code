    <Grid.ContextMenu>
        <ContextMenu Name="GroupContextMenu" Opened="GroupContextMenu_Opened" Style="{DynamicResource ContextMenuStyleBlue}">
            <MenuItem Name="ProjectsMenuItem" Header="Projects">
                <MenuItem Header="Project 1" Tag="1" Click="pmi_Click">
                     <MenuItem Header="Delete" Tag="1" Click="del_Click"/>
                </MenuItem>
                <MenuItem Header="Project 2" Tag="2" Click="pmi_Click">
                     <MenuItem Header="Delete" Tag="2" Click="del_Click"/>
                </MenuItem>                
            </MenuItem>
            <MenuItem Name="PropertiesMenuItem" Header="Properties" Click="Properties_Click" />
            <MenuItem Name="ConflictsMenuItem" Header="Conflicts"  />
        </ContextMenu>
    </Grid.ContextMenu>
