    <Window x:Class="ListViewItemSeparator.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:system="clr-namespace:System;assembly=mscorlib"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <StackPanel>
                                <Separator x:Name="Separator" />
                                <Border BorderThickness="{TemplateBinding Border.BorderThickness}" 
                                        Padding="{TemplateBinding Control.Padding}" 
                                        BorderBrush="{TemplateBinding Border.BorderBrush}" 
                                        Background="{TemplateBinding Panel.Background}" 
                                        Name="Bd" SnapsToDevicePixels="True">
                                    <ContentPresenter Content="{TemplateBinding ContentControl.Content}" 
                                                      ContentTemplate="{TemplateBinding ContentControl.ContentTemplate}" 
                                                      ContentStringFormat="{TemplateBinding ContentControl.ContentStringFormat}" 
                                                      HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" 
                                                      VerticalAlignment="{TemplateBinding Control.VerticalContentAlignment}" 
                                                      SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
                                </Border>
                            </StackPanel>
                            <ControlTemplate.Triggers>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="UIElement.IsMouseOver" Value="True" />
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Panel.Background" TargetName="Bd" Value="#1F26A0DA" />
                                    <Setter Property="Border.BorderBrush" TargetName="Bd" Value="#A826A0DA" />
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="False" />
                                        <Condition Property="Selector.IsSelected" Value="True" />
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Panel.Background" TargetName="Bd" Value="#3DDADADA" />
                                    <Setter Property="Border.BorderBrush" TargetName="Bd" Value="#FFDADADA" />
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="True" />
                                            <Condition Property="Selector.IsSelected" Value="True" />
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Panel.Background" TargetName="Bd" Value="#3D26A0DA" />
                                    <Setter Property="Border.BorderBrush" TargetName="Bd" Value="#FF26A0DA" />
                                </MultiTrigger>
                                <Trigger Property="UIElement.IsEnabled" Value="False">
                                    <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                </Trigger>
                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource PreviousData}}" Value="{x:Null}">
                                    <Setter TargetName="Separator" Property="Visibility" Value="Collapsed"></Setter>
                                </DataTrigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
 
                <Setter Property="FocusVisualStyle" Value="{x:Null}" />    
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Background" Value="White"></Setter>
                    </Trigger>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                        <Setter Property="Background" Value="#E6E6E6"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        
        <Grid>
            <ListView ItemsControl.AlternationCount="2">
                <system:String>First item</system:String>
                <system:String>Second item</system:String>
                <system:String>Third item</system:String>
                <system:String>Fourth item</system:String>
                <system:String>Fifth item</system:String>
            </ListView>
        </Grid>
    </Window>
