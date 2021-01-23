    <Style TargetType="{x:Type RibbonButton}" BasedOn="{StaticResource {x:Type RibbonButton}}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="RibbonButton" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
                    <Border BorderThickness="{TemplateBinding Border.BorderThickness}" CornerRadius="{TemplateBinding RibbonControlService.CornerRadius}" BorderBrush="{TemplateBinding Border.BorderBrush}" Background="{TemplateBinding Panel.Background}" Name="OuterBorder" SnapsToDevicePixels="True">
                        <Border BorderThickness="{TemplateBinding Border.BorderThickness}" Padding="{TemplateBinding Control.Padding}" CornerRadius="{TemplateBinding RibbonControlService.CornerRadius}" BorderBrush="#00FFFFFF" Name="InnerBorder">
                            <StackPanel Name="StackPanel">
                                <Image Source="{TemplateBinding RibbonControlService.LargeImageSource}" Name="PART_Image" Width="32" Height="32" Margin="{DynamicResource {ComponentResourceKey TypeInTargetAssembly=Ribbon, ResourceId=LargeImageMargin}}" HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" VerticalAlignment="Center" RenderOptions.BitmapScalingMode="NearestNeighbor" />
                                <Grid Name="Grid" HorizontalAlignment="Center" VerticalAlignment="Center">
                                    <RibbonTwoLineText TextAlignment="Center" LineHeight="13" LineStackingStrategy="BlockLineHeight" Text="{TemplateBinding RibbonControlService.Label}" Name="TwoLineText" Margin="1,1,1,0" HorizontalAlignment="Center" VerticalAlignment="Top" />
                                </Grid>
                            </StackPanel>
                        </Border>
                    </Border>
                    <ControlTemplate.Triggers>
                        <DataTrigger Binding="{Binding Path=ControlSizeDefinition.ImageSize, RelativeSource={RelativeSource Mode=Self}}" Value="Large">
                            <Setter Property="FrameworkElement.MinWidth">
                                <Setter.Value>
                                    <s:Double>44</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.Height">
                                <Setter.Value>
                                    <s:Double>66</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.MinHeight" TargetName="Grid">
                                <Setter.Value>
                                    <s:Double>26</s:Double>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=ControlSizeDefinition.ImageSize, RelativeSource={RelativeSource Mode=Self}}" Value="Small">
                            <Setter Property="FrameworkElement.Height">
                                <Setter.Value>
                                    <s:Double>22</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.Margin" TargetName="PART_Image">
                                <Setter.Value>
                                    <Thickness>1,0,1,0</Thickness>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Image.Source" TargetName="PART_Image">
                                <Setter.Value>
                                    <Binding Path="SmallImageSource" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.Width" TargetName="PART_Image">
                                <Setter.Value>
                                    <s:Double>16</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.Height" TargetName="PART_Image">
                                <Setter.Value>
                                    <s:Double>16</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.HorizontalAlignment" TargetName="TwoLineText">
                                <Setter.Value>
                                    <x:Static Member="HorizontalAlignment.Left" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="FrameworkElement.Margin" TargetName="TwoLineText">
                                <Setter.Value>
                                    <Thickness>1,1,1,1</Thickness>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="StackPanel.Orientation" TargetName="StackPanel">
                                <Setter.Value>
                                    <x:Static Member="Orientation.Horizontal" />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=ControlSizeDefinition.ImageSize, RelativeSource={RelativeSource Mode=Self}}" Value="Small" />
                                <Condition Binding="{Binding Path=IsInQuickAccessToolBar, RelativeSource={RelativeSource Mode=Self}}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="FrameworkElement.Height">
                                <Setter.Value>
                                    <s:Double>NaN</s:Double>
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <DataTrigger Binding="{Binding Path=ControlSizeDefinition.IsLabelVisible, RelativeSource={RelativeSource Mode=Self}}" Value="False">
                            <Setter Property="UIElement.Visibility" TargetName="TwoLineText">
                                <Setter.Value>
                                    <x:Static Member="Visibility.Collapsed" />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Path=ControlSizeDefinition.ImageSize, RelativeSource={RelativeSource Mode=Self}}" Value="Collapsed">
                            <Setter Property="UIElement.Visibility" TargetName="PART_Image">
                                <Setter.Value>
                                    <x:Static Member="Visibility.Collapsed" />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <Trigger Property="UIElement.IsMouseOver">
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="MouseOverBackground" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="MouseOverBorderBrush" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="InnerBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#80FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>True</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <Trigger Property="UIElement.IsKeyboardFocused">
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="FocusedBackground" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="FocusedBorderBrush" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="InnerBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#80FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>True</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <Trigger Property="ButtonBase.IsPressed">
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="PressedBackground" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="PressedBorderBrush" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="InnerBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>True</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <Trigger Property="RibbonControlService.IsInControlGroup">
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Binding Path="Ribbon.BorderBrush" RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderThickness" TargetName="OuterBorder">
                                <Setter.Value>
                                    <Thickness>0,0,1,0</Thickness>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="OuterBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="InnerBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>True</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <Trigger Property="UIElement.IsEnabled">
                            <Setter Property="UIElement.Opacity" TargetName="PART_Image">
                                <Setter.Value>
                                    <s:Double>0.5</s:Double>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#FF9E9E9E</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>False</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <DataTrigger Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True">
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.MenuTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="OuterBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsMouseOver, RelativeSource={RelativeSource Mode=TemplatedParent}}" Value="True" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlLightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsMouseOver, RelativeSource={RelativeSource Mode=TemplatedParent}}" Value="True" />
                                <Condition Binding="{Binding Path=IsEnabled, RelativeSource={RelativeSource Mode=Self}}" Value="False" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsDropDownOpen, RelativeSource={RelativeSource Mode=TemplatedParent}, FallbackValue=false}" Value="True" />
                                <Condition Binding="{Binding Path=IsEnabled, RelativeSource={RelativeSource Mode=Self}}" Value="False" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlLightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsMouseOver, RelativeSource={RelativeSource Mode=Self}}" Value="True" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlLightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="OuterBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="InnerBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsKeyboardFocused, RelativeSource={RelativeSource Mode=Self}}" Value="True" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlLightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="OuterBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="InnerBorder">
                                <Setter.Value>
                                    <SolidColorBrush>#00FFFFFF</SolidColorBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsPressed, RelativeSource={RelativeSource Mode=Self}}" Value="True" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Panel.Background" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlDarkBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Border.CornerRadius" TargetName="OuterBorder">
                                <Setter.Value>
                                    <CornerRadius>0,0,0,0</CornerRadius>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsInControlGroup, RelativeSource={RelativeSource Mode=Self}}" Value="True" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Border.BorderBrush" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlLightLightBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Path=IsEnabled, RelativeSource={RelativeSource Mode=Self}}" Value="False" />
                                <Condition Binding="{Binding Path=(SystemParameters.HighContrast)}" Value="True" />
                            </MultiDataTrigger.Conditions>
                            <Setter Property="TextElement.Foreground" TargetName="OuterBorder">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
