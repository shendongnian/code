    <Page.Resources>
        <local:InvBoolConverter x:Key="InvBoolConverter" />
    </Page.Resources>
    <Page.DataContext>
        <local:MainPageViewModel x:Name="vm" />
    </Page.DataContext>
    
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" x:Name="MainGrid">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="textSwitcher">
                <VisualState>
                    <VisualState.StateTriggers>
                        <StateTrigger IsActive="{Binding IsRedTrigger, Converter={StaticResource InvBoolConverter}}" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="txtBlock.Foreground" Value="Blue" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState>
                    <VisualState.StateTriggers>
                        <StateTrigger IsActive="{Binding IsRedTrigger}" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="txtBlock.Foreground" Value="Red" />
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
    
        <StackPanel Orientation="Vertical">
            <Button Content="Switch" Command="{x:Bind vm.SwitchClickCommand}" />
        </StackPanel>
    
        <TextBlock x:Name="txtBlock" Margin="100" Foreground="Blue">My Text</TextBlock>
    </Grid>
