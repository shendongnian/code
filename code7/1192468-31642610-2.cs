    <ControlTemplate>
        <Border BorderThickness="1" CornerRadius="1.5" x:Name="border">
            <Border.Background>
                <LinearGradientBrush StartPoint="0,0" EndPoint="0,1">
                    <GradientStop Color="{Binding ElementName=Canvas1, Path=Tag}" Offset="0" />
                    <GradientStop Color="{Binding ElementName=Canvas2, Path=Tag}" Offset="1" />
                </LinearGradientBrush>
            </Border.Background>
            <Grid>
                <Canvas Name="Canvas1" Visibility="Collapsed">
                    <Canvas.Tag>
                        <Color>#FF28AAE6</Color>
                    </Canvas.Tag>
                </Canvas>
                <Canvas Name="Canvas2" Visibility="Collapsed">
                    <Canvas.Tag>
                        <Color>#FF0A78AA</Color>
                    </Canvas.Tag>
                </Canvas>
            </Grid>
        </Border>
    
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter TargetName="Canvas1" Property="Tag" Value="Yellow" />
                <Setter TargetName="Canvas2" Property="Tag" Value="Green" />
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
