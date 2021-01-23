        <Window.Resources>
        <SolidColorBrush x:Key="TextBox.Static.Border" Color="#FFABAdB3"/>
        <SolidColorBrush x:Key="TextBox.MouseOver.Border" Color="#FF7EB4EA"/>
        <SolidColorBrush x:Key="TextBox.Focus.Border" Color="#FF569DE5"/>
        <Style TargetType="{x:Type TextBox}">
            <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}"/>
            <Setter Property="BorderBrush" Value="{StaticResource TextBox.Static.Border}"/>
            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="KeyboardNavigation.TabNavigation" Value="None"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="FocusVisualStyle" Value="{x:Null}"/>
            <Setter Property="AllowDrop" Value="true"/>
            <Setter Property="ScrollViewer.PanningMode" Value="VerticalFirst"/>
            <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type TextBox}">
                        <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                            <ScrollViewer x:Name="PART_ContentHost" Focusable="false" HorizontalScrollBarVisibility="Hidden" VerticalScrollBarVisibility="Hidden"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsEnabled" Value="false">
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="true">
                                <Setter Property="BorderBrush" TargetName="border" Value="Transparent"/>
                            </Trigger>
                            <Trigger Property="IsKeyboardFocused" Value="true">
                                <Setter Property="BorderBrush" TargetName="border" Value="Transparent"/>
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.Target="{Binding ElementName=rectangle}">
                                                <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="1"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.66" Value="1"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="1"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" Storyboard.Target="{Binding ElementName=rectangle}">
                                                <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="51.274"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.66" Value="51.274"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="97.205"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.Target="{Binding ElementName=rectangle}">
                                                <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="53.542"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:0.66" Value="53.542"/>
                                                <EasingDoubleKeyFrame KeyTime="0:0:1.2" Value="4.625"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="IsInactiveSelectionHighlightEnabled" Value="true"/>
                        <Condition Property="IsSelectionActive" Value="false"/>
                    </MultiTrigger.Conditions>
                    <Setter Property="SelectionBrush" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
                </MultiTrigger>
            </Style.Triggers>
            </Style>
           </Window.Resources>
           <Grid>
        <TextBox Margin="180,142.5,129,153.5" BorderBrush="{x:Null}" Background="{x:Null}" SelectionBrush="{x:Null}" Style="{DynamicResource TextBoxStyle1}">TextBox</TextBox>
        <Path Data="M0.5,0.75 L170,0.5" Fill="#FFF4F4F5" HorizontalAlignment="Left" Height="1.75" Margin="180,163.781,0,0" Stroke="Black" VerticalAlignment="Top" Width="208" Stretch="Fill" RenderTransformOrigin="0.5,0.5">
            <Path.RenderTransform>
                <TransformGroup>
                    <ScaleTransform/>
                    <SkewTransform/>
                    <RotateTransform Angle="0.204"/>
                    <TranslateTransform/>
                </TransformGroup>
            </Path.RenderTransform>
        </Path>
        <Rectangle x:Name="rectangle" Fill="#FF00E8FF" HorizontalAlignment="Left" Height="1.125" Margin="278.29,164.083,0,0" Stroke="{x:Null}" VerticalAlignment="Top" Width="2.13" RenderTransformOrigin="0.5,0.5" Opacity="0">
            <Rectangle.RenderTransform>
                <TransformGroup>
                    <ScaleTransform/>
                    <SkewTransform/>
                    <RotateTransform/>
                    <TranslateTransform/>
                </TransformGroup>
            </Rectangle.RenderTransform>
        </Rectangle>
         </Grid>
 
