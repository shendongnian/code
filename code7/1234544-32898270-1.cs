    <Color x:Key="Color.Control.Border.Focus">#FF00BCD4</Color>
        <SolidColorBrush x:Key="SolidColorBrush.Control.Border" Color="#FFABADB3" />
        <SolidColorBrush x:Key="SolidColorBrush.Hint" Color="LightGray" />
        <Style TargetType="{x:Type local:AnimatedTextBox}">
            <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}" />
            <Setter Property="BorderBrush" Value="{StaticResource SolidColorBrush.Control.Border}" />
            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}" />
            <Setter Property="BorderThickness" Value="1" />
            <Setter Property="KeyboardNavigation.TabNavigation" Value="None" />
            <Setter Property="HorizontalContentAlignment" Value="Left" />
            <Setter Property="FocusVisualStyle" Value="{x:Null}" />
            <Setter Property="AllowDrop" Value="true" />
            <Setter Property="ScrollViewer.PanningMode" Value="VerticalFirst" />
            <Setter Property="Stylus.IsFlicksEnabled" Value="False" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:AnimatedTextBox}">
                        <ControlTemplate.Resources />
                        <Border x:Name="Border"
                                Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="0,0,0,2"
                                SnapsToDevicePixels="True">
                            <StackPanel>
                                <TextBlock x:Name="LabelTextBlock"
                                           Focusable="False"
                                           Foreground="{TemplateBinding BorderBrush}"
                                           RenderTransformOrigin="0.5,0.5"
                                           Text="{TemplateBinding Label}">
                                    <TextBlock.RenderTransform>
                                        <TransformGroup>
                                            <ScaleTransform ScaleX=".75" ScaleY=".75" />
                                            <TranslateTransform X="0" Y="0" />
                                        </TransformGroup>
                                    </TextBlock.RenderTransform>
                                </TextBlock>
                                <Grid>
                                    <ScrollViewer x:Name="PART_ContentHost"
                                                  Focusable="false"
                                                  HorizontalScrollBarVisibility="Hidden"
                                                  VerticalScrollBarVisibility="Hidden" />
                                    <TextBlock x:Name="HintTextBlock"
                                               Margin="5 0 0 0"
                                               Focusable="False"
                                               Foreground="{StaticResource SolidColorBrush.Hint}"
                                               IsHitTestVisible="False"
                                               Opacity="0"
                                               Text="{TemplateBinding Hint}" />
                                </Grid>
                            </StackPanel>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsFocused" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ColorAnimation Duration="0:0:0.6"
                                                            Storyboard.TargetProperty="BorderBrush.Color"
                                                            To="{StaticResource Color.Control.Border.Focus}" />
                                            <ColorAnimation Duration="0:0:0.6"
                                                            Storyboard.TargetName="LabelTextBlock"
                                                            Storyboard.TargetProperty="Foreground.Color"
                                                            To="{StaticResource Color.Control.Border.Focus}" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ColorAnimation Duration="0:0:0.6" Storyboard.TargetProperty="BorderBrush.Color" />
                                            <ColorAnimation Duration="0:0:0.6"
                                                            Storyboard.TargetName="LabelTextBlock"
                                                            Storyboard.TargetProperty="Foreground.Color" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding Path=Text.Length, RelativeSource={RelativeSource Self}}" Value="0" />
                                    <Condition Binding="{Binding Path=IsFocused, RelativeSource={RelativeSource Self}}" Value="false" />
                                </MultiDataTrigger.Conditions>
                                <MultiDataTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"
                                                             To="1" />
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"
                                                             To="1" />
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"
                                                             To="15" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiDataTrigger.EnterActions>
                                <MultiDataTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" />
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" />
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="LabelTextBlock"
                                                             Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiDataTrigger.ExitActions>
                            </MultiDataTrigger>
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding Path=Text.Length, RelativeSource={RelativeSource Self}}" Value="0" />
                                    <Condition Binding="{Binding Path=IsFocused, RelativeSource={RelativeSource Self}}" Value="true" />
                                </MultiDataTrigger.Conditions>
                                <MultiDataTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="HintTextBlock"
                                                             Storyboard.TargetProperty="Opacity"
                                                             To="1" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiDataTrigger.EnterActions>
                                <MultiDataTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2"
                                                             Storyboard.TargetName="HintTextBlock"
                                                             Storyboard.TargetProperty="Opacity" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiDataTrigger.ExitActions>
                            </MultiDataTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
