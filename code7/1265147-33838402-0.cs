    <Grid MouseMove="Grid_MouseMove">
        <TextBlock Text="Hello, World" FontSize="40"
                   HorizontalAlignment="Center" VerticalAlignment="Center"/>
        <Path Fill="Black">
            <Path.Data>
                <CombinedGeometry GeometryCombineMode="Exclude">
                    <CombinedGeometry.Geometry1>
                        <RectangleGeometry Rect="0,0,10000,10000"/>
                    </CombinedGeometry.Geometry1>
                    <CombinedGeometry.Geometry2>
                        <EllipseGeometry x:Name="circle" RadiusX="100" RadiusY="100"/>
                    </CombinedGeometry.Geometry2>
                </CombinedGeometry>
            </Path.Data>
        </Path>
    </Grid>
