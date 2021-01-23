    <TabControl x:Name="tabControl" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
        <TabItem Header="Clipboard Buffer">
            <ListView Name="clipboardListView" ScrollViewer.CanContentScroll="True">
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                    </Style>
                </ListView.ItemContainerStyle>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Border BorderThickness="2" BorderBrush="Black" CornerRadius="2,2,2,2">
                                <DockPanel Background="AliceBlue">
                                    <TextBlock Text="{Binding UnicodeText}" DockPanel.Dock="Top" />
                                </DockPanel>
                            </Border>
                        </Grid>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </TabItem>
    </TabControl>
