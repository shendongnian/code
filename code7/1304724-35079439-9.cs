    <Page.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Hamburger.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <SplitView DisplayMode="CompactOverlay" IsPaneOpen="True">
            <SplitView.Pane>
                <StackPanel>
                    <Button Style="{StaticResource HamburgerStyle}" />
                </StackPanel>
            </SplitView.Pane>
        </SplitView>
    </Grid>
