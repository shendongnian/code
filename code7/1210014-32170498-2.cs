        <ListView ItemsSource="{Binding}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <TextBlock Text="{Binding Text}" />
                        <Canvas>
                            <Rectangle Visibility="{Binding ShowOverlap}" Width="100" Height="100" Opacity="0.5">
                                <Rectangle.Fill>
                                    <ImageBrush ImageSource="house2.png" Stretch="UniformToFill" />
                                </Rectangle.Fill>
                            </Rectangle>
                        </Canvas>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
