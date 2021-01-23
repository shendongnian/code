        <Image x:Key="InvertImageBtn2" Source="MyResources/Koala.jpg" />
        <Image x:Key="LogoFooterBackgroundStyle2" Source="MyResources/Penguins.jpg" />
        <Color x:Key="ButtonLowerPartKey">#FFD5E0EE</Color>
        <Color x:Key="ButtonUpperPartKey">#FFEAF1F8</Color>
        <Color x:Key="PressedColorButtonLowerPartKey">#FFF4C661</Color>
        <Color x:Key="PressedButtonUpperPartKey">#FFF4CC87</Color>
        <Color x:Key="HooveredButtonLowerPartKey">#FFFFD06D</Color>
        <Color x:Key="HooveredButtonUpperPartKey">#FFFFF0DF</Color>
        <Style x:Key="SpecialButtonStyle" TargetType="ToggleButton" BasedOn="{StaticResource {x:Type ToggleButton}}">
            <Setter Property="Padding" Value="5">
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate>
                        <Grid x:Name="Grid">
                            <Ellipse x:Name="ButtonControlBorder" Stroke="{TemplateBinding BorderBrush}" 
                                 StrokeThickness="{TemplateBinding BorderThickness}" 
                                 Width="{TemplateBinding Width}" Height="{TemplateBinding Height}">
                                <Ellipse.Fill>
                                    <LinearGradientBrush x:Name="BrushKey" MappingMode="RelativeToBoundingBox" SpreadMethod="Repeat" StartPoint="0.5,0" EndPoint="0.5,1">
                                        <LinearGradientBrush.GradientStops>
                                            <GradientStop Offset="0.5" Color="{StaticResource ButtonUpperPartKey}" />
                                            <GradientStop Offset="0.5" Color="{StaticResource ButtonUpperPartKey}" />
                                            <GradientStop Offset="0.5" Color="{StaticResource ButtonLowerPartKey}" />
                                        </LinearGradientBrush.GradientStops>
                                    </LinearGradientBrush>
                                </Ellipse.Fill>
                            </Ellipse>
                            <Ellipse x:Name="Pressed" Width="{TemplateBinding Width}" Height="{TemplateBinding Height}" Opacity="0">
                                <Ellipse.Fill>
                                    <LinearGradientBrush x:Name="PressedBrushKey" MappingMode="RelativeToBoundingBox" SpreadMethod="Repeat" StartPoint="0.5,0" EndPoint="0.5,1">
                                        <LinearGradientBrush.GradientStops>
                                            <GradientStop Offset="0.5" Color="{StaticResource PressedButtonUpperPartKey}" />
                                            <GradientStop Offset="0.5" Color="{StaticResource PressedButtonUpperPartKey}" />
                                            <GradientStop Offset="0.5" Color="{StaticResource PressedColorButtonLowerPartKey}" />
                                        </LinearGradientBrush.GradientStops>
                                    </LinearGradientBrush>
                                </Ellipse.Fill>
                            </Ellipse>
                            <Ellipse x:Name="InnerPressed" 
                                Width="{Binding ElementName=Pressed, Path=Width}" Height="{Binding ElementName=Pressed, Path=Height}" 
                                Stroke="DarkOrange" Opacity="0" StrokeThickness="1" SnapsToDevicePixels="True" Fill="Transparent"/>
                            <ContentPresenter Content="{TemplateBinding Button.Content}" HorizontalAlignment="Center" VerticalAlignment="Center">
                                <ContentPresenter.OpacityMask>
                                    <VisualBrush Visual="{Binding ElementName=ButtonControlBorder}" />
                                </ContentPresenter.OpacityMask>
                            </ContentPresenter>
                            <Grid.Triggers>
                                <EventTrigger RoutedEvent="Mouse.MouseEnter">
                                    <BeginStoryboard x:Name="MouseEnterStoryboard">
                                        <Storyboard>
                                            <ColorAnimation Storyboard.TargetName="BrushKey" Storyboard.TargetProperty="GradientStops[0].Color" From="{StaticResource ButtonUpperPartKey}" To="{StaticResource HooveredButtonUpperPartKey}" Duration="0:0:0.3" AutoReverse="False" />
                                            <ColorAnimation Storyboard.TargetName="BrushKey" Storyboard.TargetProperty="GradientStops[2].Color" From="{StaticResource ButtonLowerPartKey}" To="{StaticResource HooveredButtonLowerPartKey}" Duration="0:0:0.3" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger>
                                <EventTrigger RoutedEvent="Mouse.MouseLeave">
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ColorAnimation Storyboard.TargetName="BrushKey" Storyboard.TargetProperty="GradientStops[0].Color" From="{StaticResource HooveredButtonUpperPartKey}" To="{StaticResource ButtonUpperPartKey}" Duration="0:0:1" AutoReverse="False" />
                                            <ColorAnimation Storyboard.TargetName="BrushKey" Storyboard.TargetProperty="GradientStops[2].Color" From="{StaticResource HooveredButtonLowerPartKey}" To="{StaticResource ButtonLowerPartKey}" Duration="0:0:1" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger>
                            </Grid.Triggers>
                        </Grid>
                        <ControlTemplate.Resources>
                            <Storyboard x:Key="MouseUpTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Pressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="0" />
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="MouseDownTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Pressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.05" Value="0.8" />
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="InnerPressedMouseUpTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="InnerPressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="0" />
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="InnerPressedMouseDownTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="InnerPressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.05" Value="1" />
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                        </ControlTemplate.Resources>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" SourceName="Grid" Value="True">
                                <Setter Property="Stroke" TargetName="ButtonControlBorder">
                                    <Setter.Value>
                                        <SolidColorBrush Color="{StaticResource HooveredButtonLowerPartKey}">
                                        </SolidColorBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property="ButtonBase.IsPressed" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseDownTimeLine}" />
                                    <BeginStoryboard Storyboard="{StaticResource InnerPressedMouseDownTimeLine}">
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseUpTimeLine}" />
                                    <BeginStoryboard Storyboard="{StaticResource InnerPressedMouseUpTimeLine}">
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
