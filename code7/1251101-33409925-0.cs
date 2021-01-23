            <Style x:Key="CustomThumbForSlider" TargetType="{x:Type Thumb}">
            <Setter Property="OverridesDefaultStyle" Value="True"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Thumb}">
                        <Rectangle Fill="#FF462857" StrokeThickness="0" Height="{TemplateBinding Property=Height}" Width="4"/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="MyCustomStyleForSlider" TargetType="{x:Type Slider}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Slider}">
                        <Border Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}">
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="Auto" MinHeight="{TemplateBinding MinHeight}"/>
                                </Grid.RowDefinitions>
                                <TickBar x:Name="TopTick" Visibility="Collapsed" Fill="{TemplateBinding Foreground}" Placement="Top" Height="4" Grid.Row="0"/>
                                <TickBar x:Name="BottomTick" Visibility="Collapsed" Fill="{TemplateBinding Foreground}" Placement="Bottom" Height="4" Grid.Row="0"/>
                                <Border x:Name="TrackBackground" BorderThickness="1" CornerRadius="1" Margin="5,0" VerticalAlignment="Center" Height="4.0" Grid.Row="1" >
                                    <Canvas Margin="-6,-1">
                                        <Rectangle Visibility="Hidden" x:Name="PART_SelectionRange" Height="4.0" Fill="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}" Stroke="{DynamicResource {x:Static SystemColors.ControlDarkDarkBrushKey}}" StrokeThickness="1.0"/>
                                    </Canvas>
                                </Border>
                                <Track x:Name="PART_Track" Grid.Row="1" Height="{TemplateBinding Property=Height}">
                                    <Track.DecreaseRepeatButton>
                                        <RepeatButton Command="{x:Static Slider.DecreaseLarge}" Background="#FF8D7D97" BorderThickness="1 1 0 1"/>
                                    </Track.DecreaseRepeatButton>
                                    <Track.IncreaseRepeatButton>
                                        <RepeatButton Command="{x:Static Slider.IncreaseLarge}" Background="#FFC6BCCC" BorderThickness="0 1 1 1"/>
                                    </Track.IncreaseRepeatButton>
                                    <Track.Thumb>
                                        <Thumb x:Name="Thumb" Background="Black" Style="{StaticResource CustomThumbForSlider}"/>
                                    </Track.Thumb>
                                </Track>
                            </Grid>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
