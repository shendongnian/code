    <ItemsControl ItemsSource="{Binding Lines}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Canvas>
                    <Polyline Points="{Binding LinePoints}"
                              StrokeThickness="2.0" Stroke="Black"/>
                    <ItemsControl ItemsSource="{Binding LinePoints}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <Canvas/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Path StrokeThickness="1.0" Stroke="Black" Fill="MistyRose">
                                    <Path.Data>
                                        <EllipseGeometry Center="{Binding}"
                                                         RadiusX="4" RadiusY="4"/>
                                    </Path.Data>
                                </Path>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </Canvas>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
