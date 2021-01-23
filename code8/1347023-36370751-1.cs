    <Grid Name="grid">
        <Canvas Background="Purple">
            <Canvas.Style>
                <Style TargetType="Canvas">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsPressed, RelativeSource={RelativeSource Mode=TemplatedParent}}" Value="True">
                            <Setter Property="Visibility" Value="Collapsed"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Canvas.Style>
            <TextBlock Text="ic_max" FontSize="48"/>
        </Canvas>
        <Canvas Background="Green">
            <Canvas.Style>
                <Style TargetType="Canvas">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsPressed, RelativeSource={RelativeSource Mode=TemplatedParent}}" Value="True">
                            <Setter Property="Visibility" Value="Visible"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding IsPressed, RelativeSource={RelativeSource Mode=TemplatedParent}}" Value="False">
                            <Setter Property="Visibility" Value="Collapsed"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Canvas.Style>
            <TextBlock Text="ic_restore" FontSize="48"/>
        </Canvas>
    </Grid>
