    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="LoginGroup">
                <VisualState x:Name="LoggedIn">
                    <VisualState.StateTriggers>
                        <triggers:EqualsStateTrigger EqualTo="True" Value="{Binding Path=IsLoggedIn}" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="LoggedInGrid.Visibility" Value="Visible"/>
                        <Setter Target="LoggedOutGrid.Visibility" Value="Collapsed" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="LoggedOut">
                    <VisualState.StateTriggers>
                        <triggers:EqualsStateTrigger EqualTo="False" Value="{Binding Path=IsLoggedIn}" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="LoggedInGrid.Visibility" Value="Collapsed"/>
                        <Setter Target="LoggedOutGrid.Visibility" Value="Visible" />
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
        <Grid x:Name="LayoutRoot">
            <Grid x:Name="LoggedInGrid">                
            </Grid>
            <Grid x:Name="LoggedOutGrid">
            </Grid>
        </Grid>
    </Grid>nter code here
 
