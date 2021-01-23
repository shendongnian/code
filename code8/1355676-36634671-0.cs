    <ItemsControl
        ItemsSource="{Binding CombinedPieChartData}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Canvas>
                    <Canvas.Resources>
                        <local:BindingProxy  x:Key="proxy" Data="{Binding}" />
                    </Canvas.Resources>
                    <Path Stroke="Black" StrokeThickness="1" Fill="{Binding Color}">
                        <Path.Data>
                            <GeometryGroup>
                                <PathGeometry>
                                    <PathFigure StartPoint="{Binding Source={StaticResource proxy}, Path=Data.FirstPoint1}">
                                        <PathFigure.Segments>
                                            <LineSegment Point="{Binding Source={StaticResource proxy}, Path=Data.SecondPoint1}"/>
                                        </PathFigure.Segments>
                                    </PathFigure>
                                </PathGeometry>
                            </GeometryGroup>
                        </Path.Data>
                    </Path>
                </Canvas>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
