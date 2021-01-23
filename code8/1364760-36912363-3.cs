    <Page.Resources>
        <DataTemplate x:DataType="local:Recording" x:Key="recordingitem">
            <StackPanel>
                <Image Source="{Binding ImageUri, Mode=TwoWay}" Height="100" Opacity="1" Stretch="Uniform" />
                <TextBlock Text="{x:Bind ArtistName}" />
                <TextBlock Text="{x:Bind CompositionName}" />
                <TextBlock Text="{x:Bind ReleaseDateTime}" />
            </StackPanel>
        </DataTemplate>
    </Page.Resources>
    <Page.DataContext>
        <local:RecordingViewModel x:Name="vm" />
    </Page.DataContext>
    
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Hub>
            <HubSection x:Name="section1" Width="600">
                <DataTemplate>
                    <Grid>
                        <GridView ItemsSource="{Binding recordings}" ItemTemplate="{StaticResource recordingitem}"  Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" x:Name="RecordingGrid">
                        </GridView>
                    </Grid>
                </DataTemplate>
            </HubSection>
        </Hub>
    </Grid>
