    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="0"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="PrimaryHome.Visibility" Value="Collapsed"/>
                        <Setter Target="PrimaryAdd.Visibility" Value="Collapsed"/>
                    </VisualState.Setters>
                </VisualState>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="720"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="SecondHome.Visibility" Value="Collapsed"/>
                        <Setter Target="SecondAdd.Visibility" Value="Collapsed"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
    </Grid>
    <Page.TopAppBar>
        <CommandBar x:Name="TopCommands" >
            <CommandBar.PrimaryCommands>
                <AppBarButton Name="PrimaryHome" Icon="Home" Label="Home"/>
                <AppBarButton Name="PrimaryAdd" Icon="Add" Label="Add"  />
            </CommandBar.PrimaryCommands>
            <CommandBar.SecondaryCommands>
                <AppBarButton Name="SecondHome" Icon="Home" Label="Home" />
                <AppBarButton Name="SecondAdd" Icon="Add" Label="Add" />
            </CommandBar.SecondaryCommands>
        </CommandBar>
    </Page.TopAppBar>
