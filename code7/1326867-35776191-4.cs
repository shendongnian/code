    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Canvas>
                <Path StrokeThickness="2.0" Stroke="Black" Data="{Binding LineGeometry}" />
                <ItemsControl ItemsSource="{Binding Points}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <Canvas/>
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Path StrokeThickness="1.0" Stroke="Black" Fill="MistyRose">
                                <Path.Data>
                                    <EllipseGeometry
                                        Center="{Binding
                                            Converter={StaticResource LinePointConverter}}"
                                        RadiusX="4" RadiusY="4"/>
                                </Path.Data>
                            </Path>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </Canvas>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
