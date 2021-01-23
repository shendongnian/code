    <Page.DataContext>
        <local:RecordingViewModel x:Name="vm" />
    </Page.DataContext>
    
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Hub>
            <HubSection x:Name="section1" Width="600">
                <DataTemplate>
                    <Grid>
                        <GridView ItemsSource="{Binding recordings}"  Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" x:Name="RecordingGrid">
                            <GridView.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel>
                                        <Image Source="{Binding ImageUri, Mode=TwoWay}" Height="100" Opacity="1" Stretch="Uniform" />
                                        <TextBlock Text="{Binding ArtistName}" />
                                        <TextBlock Text="{Binding CompositionName}" />
                                        <TextBlock Text="{Binding ReleaseDateTime}" />
                                    </StackPanel>
                                </DataTemplate>
                            </GridView.ItemTemplate>
                        </GridView>
                    </Grid>
                </DataTemplate>
            </HubSection>
        </Hub>
    </Grid>
