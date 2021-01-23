    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="0"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="TopCommands.Visibility" Value="Visible"/>
                    </VisualState.Setters>
                </VisualState>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="720"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="BottonCommands.Visibility" Value="Visible"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
    </Grid>
    <Page.TopAppBar>
        <CommandBar x:Name="TopCommands" Visibility="Collapsed" >
            <CommandBar.PrimaryCommands>
                <AppBarButton Name="PrimaryHome" Icon="Home" Label="Home"/>
                <AppBarButton Name="PrimaryAdd" Icon="Add" Label="Add"  />
            </CommandBar.PrimaryCommands>
        </CommandBar>
    </Page.TopAppBar>
    <Page.BottomAppBar>
        <CommandBar x:Name="BottonCommands" Visibility="Collapsed">
            <CommandBar.PrimaryCommands>
                <AppBarButton Name="BottonPrimaryHome" Icon="Home" Label="Home"/>
                <AppBarButton Name="BottonPrimaryAdd" Icon="Add" Label="Add"  />
            </CommandBar.PrimaryCommands>
        </CommandBar>
    </Page.BottomAppBar>
