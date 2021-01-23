    <Style x:Key="GridSplitterStyle1" TargetType="{x:Type GridSplitter}">
        <Setter Property="Background" Value="Yellow"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type GridSplitter}">
                    <Border BorderThickness="1,1,1,1">
                        <Border.BorderBrush>
                            <DrawingBrush Viewport="0,0,8,8" ViewportUnits="Absolute" TileMode="Tile">
                                <DrawingBrush.Drawing>
                                    <DrawingGroup>
                                        <GeometryDrawing Brush="Red">
                                            <GeometryDrawing.Geometry>
                                                <GeometryGroup>
                                                    <RectangleGeometry Rect="0,0,50,50" />
                                                    <RectangleGeometry Rect="50,50,50,50" />
                                                </GeometryGroup>
                                            </GeometryDrawing.Geometry>
                                        </GeometryDrawing>
                                    </DrawingGroup>
                                </DrawingBrush.Drawing>
                            </DrawingBrush>
                        </Border.BorderBrush>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
