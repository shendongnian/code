    <Grid>
        <Viewport3D>
            <Viewport3D.Camera>
                <PerspectiveCamera Position="0, 0, 4"/>
            </Viewport3D.Camera>
            <Viewport2DVisual3D x:Name="DVisual3D">
                <Viewport2DVisual3D.Transform>
                    <RotateTransform3D>
                        <RotateTransform3D.Rotation>
                            <AxisAngleRotation3D Angle="0" Axis="0, 1, 0" />
                        </RotateTransform3D.Rotation>
                    </RotateTransform3D>
                </Viewport2DVisual3D.Transform>
                <Viewport2DVisual3D.Geometry>
                    <MeshGeometry3D Positions="-1,1,0 -1,-1,0 1,-1,0 1,1,0"
                            TextureCoordinates="0,0 0,1 1,1 1,0" TriangleIndices="0 1 2 0 2 3"/>
                </Viewport2DVisual3D.Geometry>
                <Viewport2DVisual3D.Visual>
                    <Border x:Name="border"
                            Width="200"
                            Height="200"
                            BorderBrush="Black"
                            BorderThickness="1"
                            CornerRadius="4"
                            Background="LightBlue">
                        <Border.Effect>
                            <DropShadowEffect BlurRadius="20" />
                        </Border.Effect>
                        <Button VerticalAlignment="Bottom"
                                HorizontalAlignment="Center"
                                Margin="0,0,0,10"
                                Padding="5"
                                Content="Click">
                            <Button.Triggers>
                                <EventTrigger RoutedEvent="Button.Click">
                                    <BeginStoryboard>
                                        <Storyboard FillBehavior="Stop">
                                            <DoubleAnimation Storyboard.TargetName="DVisual3D"
                                            Storyboard.TargetProperty="Transform.(RotateTransform3D.Rotation).(AxisAngleRotation3D.Angle)"
                                            To="10" Duration="0:0:0.07"/>
                                            <DoubleAnimation Storyboard.TargetName="DVisual3D"
                                            Storyboard.TargetProperty="Transform.(RotateTransform3D.Rotation).(AxisAngleRotation3D.Angle)"
                                            To="-10"
                                            BeginTime="0:0:0.07"
                                            Duration="0:0:0.14" />
                                            <DoubleAnimation Storyboard.TargetName="DVisual3D"
                                            Storyboard.TargetProperty="Transform.(RotateTransform3D.Rotation).(AxisAngleRotation3D.Angle)"
                                            To="10"
                                            BeginTime="0:0:0.21"
                                            Duration="0:0:0.14" />
                                            <DoubleAnimation Storyboard.TargetName="DVisual3D"
                    
                        Storyboard.TargetProperty="Transform.(RotateTransform3D.Rotation).(AxisAngleRotation3D.Angle)"
                                        BeginTime="0:0:0.35"
                                        Duration="0:0:0.07" />
                                </Storyboard>
                            </BeginStoryboard>
                            </EventTrigger>
                            </Button.Triggers>
                    </Button>
                </Border>
            </Viewport2DVisual3D.Visual>
            <Viewport2DVisual3D.Material>
                <DiffuseMaterial Viewport2DVisual3D.IsVisualHostMaterial="True" Brush="White"/>
            </Viewport2DVisual3D.Material>
        </Viewport2DVisual3D>
        <ModelVisual3D>
            <ModelVisual3D.Content>
                <DirectionalLight Color="#FFFFFFFF" Direction="0,0,-1"/>
            </ModelVisual3D.Content>
        </ModelVisual3D>
    </Viewport3D>
