    <TabControl>
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Padding" Value="5" />
            </Style>
        </TabControl.ItemContainerStyle>
        <TabItem>
            <TabItem.Header>
                <StackPanel Orientation="Horizontal">
                    <Image Source="/WpfTutorialSamples;component/Images/bullet_blue.png" />
                    <TextBlock Text="Blue" Foreground="Blue" />
                </StackPanel>
            </TabItem.Header>
            <Label Content="Content goes here..." />
        </TabItem>
        <TabItem>
            <TabItem.Header>
                <TextBlock Text="Red" Foreground="Red" />
            </TabItem.Header>
        </TabItem>
        <TabItem>
            <TabItem.Header>
                <Rectangle Fill="Red" Width="20" Height="16" />
            </TabItem.Header>
        </TabItem>
    </TabControl>
