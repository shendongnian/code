    <Grid x:Name="Container">
        <DockPanel>
            <TextBlock DockPanel.Dock="Top">Outside of Tab</TextBlock>
            <TabControl x:Name="TabControl">
                <TabItem Header="Here">
                    <local:UserControlContainingTipFocus/>
                </TabItem>
            </TabControl>
        </DockPanel>
    </Grid>
