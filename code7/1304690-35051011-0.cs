    <Grid Grid.Row="1" Height="Auto">
        <Grid.Background>
            <LinearGradientBrush>
                <LinearGradientBrush.GradientStops>
                    <GradientStop Color="#252525" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Grid.Background>
        <ListView SelectionMode="Single" ScrollViewer.HorizontalScrollBarVisibility="Disabled" Background="Transparent" Foreground="AntiqueWhite" BorderBrush="Transparent"
                 HorizontalContentAlignment="Stretch" ItemsSource="{Binding Items}">
            <ListView.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Delete" Command="{Binding DeleteModel3DCommand}" CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=ContextMenu}, Path=PlacementTarget.SelectedItem}"/>
                </ContextMenu>
            </ListView.ContextMenu>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="SelectionChanged">
                    <i:InvokeCommandAction Command="{Binding SelectModel3DCommand}" CommandParameter="{Binding Path=SelectedItem, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListBox}}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Image Source="refresh.png" Height="100"/>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel/>
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
        </ListView>
    </Grid>
