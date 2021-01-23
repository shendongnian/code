    <Window
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApplication11"
        xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" 
        xmlns:Themes="clr-namespace:Xceed.Wpf.Toolkit.Themes;assembly=Xceed.Wpf.Toolkit" 
        x:Class="WpfApplication11.MainWindow"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525" Loaded="Window_Loaded">
    <Window.Resources>
        <Style x:Key="DateTimePickerStyle1" TargetType="{x:Type xctk:DateTimePicker}">
            <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}"/>
            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.WindowTextBrushKey}}"/>
            <Setter Property="BorderBrush" Value="{DynamicResource {ComponentResourceKey ResourceId=ControlNormalBorderKey, TypeInTargetAssembly={x:Type Themes:ResourceKeys}}}"/>
            <Setter Property="BorderThickness" Value="1,1,0,1"/>
            <Setter Property="Focusable" Value="False"/>
            <Setter Property="HorizontalContentAlignment" Value="Right"/>
            <Setter Property="TextAlignment" Value="Right"/>
            <Setter Property="TimeWatermarkTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <ContentControl Content="{Binding}" Foreground="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" Focusable="False" Margin="0,0,3,0"/>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="WatermarkTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <ContentControl Content="{Binding}" Foreground="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" Focusable="False" Margin="0,0,3,0"/>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type xctk:DateTimePicker}">
                        <Border>
                            <Grid>
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*"/>
                                        <ColumnDefinition Width="Auto"/>
                                    </Grid.ColumnDefinitions>
                                    <xctk:ButtonSpinner x:Name="PART_Spinner" AllowSpin="{TemplateBinding AllowSpin}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" ButtonSpinnerLocation="{TemplateBinding ButtonSpinnerLocation}" Background="{TemplateBinding Background}" HorizontalContentAlignment="Stretch" IsTabStop="False" ShowButtonSpinner="{TemplateBinding ShowButtonSpinner}" VerticalContentAlignment="Stretch">
                                        <xctk:WatermarkTextBox x:Name="PART_TextBox" AcceptsReturn="False" BorderThickness="0" Background="Transparent" Foreground="{TemplateBinding Foreground}" FontWeight="{TemplateBinding FontWeight}" FontStyle="{TemplateBinding FontStyle}" FontStretch="{TemplateBinding FontStretch}" FontSize="{TemplateBinding FontSize}" FontFamily="{TemplateBinding FontFamily}" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" IsUndoEnabled="True" MinWidth="20" Padding="{TemplateBinding Padding}" TextAlignment="{TemplateBinding TextAlignment}" TextWrapping="NoWrap" Text="{Binding Text, RelativeSource={RelativeSource TemplatedParent}}" TabIndex="{TemplateBinding TabIndex}" VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}" WatermarkTemplate="{TemplateBinding WatermarkTemplate}" Watermark="{TemplateBinding Watermark}"/>
                                    </xctk:ButtonSpinner>
                                    <ToggleButton x:Name="_calendarToggleButton" Background="White" Grid.Column="1" Focusable="False" IsChecked="{Binding IsOpen, RelativeSource={RelativeSource TemplatedParent}}">
                                        <ToggleButton.IsHitTestVisible>
                                            <Binding Path="IsOpen" RelativeSource="{RelativeSource TemplatedParent}">
                                                <Binding.Converter>
                                                    <xctk:InverseBoolConverter/>
                                                </Binding.Converter>
                                            </Binding>
                                        </ToggleButton.IsHitTestVisible>
                                        <ToggleButton.IsEnabled>
                                            <Binding Path="IsReadOnly" RelativeSource="{RelativeSource TemplatedParent}">
                                                <Binding.Converter>
                                                    <xctk:InverseBoolConverter/>
                                                </Binding.Converter>
                                            </Binding>
                                        </ToggleButton.IsEnabled>
                                        <ToggleButton.Style>
                                            <Style TargetType="{x:Type ToggleButton}">
                                                <Setter Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate TargetType="{x:Type ToggleButton}">
                                                            <Grid SnapsToDevicePixels="True">
                                                                <xctk:ButtonChrome x:Name="ToggleButtonChrome" CornerRadius="0" RenderMouseOver="{TemplateBinding IsMouseOver}" RenderPressed="{TemplateBinding IsPressed}" RenderChecked="{Binding IsOpen, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type xctk:DateTimePicker}}}" RenderEnabled="{Binding IsEnabled, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type xctk:DateTimePicker}}}">
                                                                    <Grid>
                                                                        <Grid.ColumnDefinitions>
                                                                            <ColumnDefinition Width="*"/>
                                                                            <ColumnDefinition Width="Auto"/>
                                                                        </Grid.ColumnDefinitions>
                                                                        <ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" HorizontalAlignment="Stretch" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="Stretch"/>
                                                                        <Grid x:Name="arrowGlyph" Grid.Column="1" IsHitTestVisible="False" Margin="5">
                                                                            <Path x:Name="Arrow" Data="M0,1C0,1 0,0 0,0 0,0 3,0 3,0 3,0 3,1 3,1 3,1 4,1 4,1 4,1 4,0 4,0 4,0 7,0 7,0 7,0 7,1 7,1 7,1 6,1 6,1 6,1 6,2 6,2 6,2 5,2 5,2 5,2 5,3 5,3 5,3 4,3 4,3 4,3 4,4 4,4 4,4 3,4 3,4 3,4 3,3 3,3 3,3 2,3 2,3 2,3 2,2 2,2 2,2 1,2 1,2 1,2 1,1 1,1 1,1 0,1 0,1z" Fill="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}" Height="4" Width="7"/>
                                                                        </Grid>
                                                                    </Grid>
                                                                </xctk:ButtonChrome>
                                                            </Grid>
                                                            <ControlTemplate.Triggers>
                                                                <Trigger Property="IsEnabled" Value="False">
                                                                    <Setter Property="Fill" TargetName="Arrow" Value="#FFAFAFAF"/>
                                                                </Trigger>
                                                            </ControlTemplate.Triggers>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </ToggleButton.Style>
                                        <ToggleButton.Visibility>
                                            <TemplateBinding Property="ShowDropDownButton">
                                                <TemplateBinding.Converter>
                                                    <BooleanToVisibilityConverter/>
                                                </TemplateBinding.Converter>
                                            </TemplateBinding>
                                        </ToggleButton.Visibility>
                                    </ToggleButton>
                                </Grid>
                                <Popup x:Name="PART_Popup" IsOpen="{Binding IsChecked, ElementName=_calendarToggleButton}" StaysOpen="False">
                                    <Border BorderBrush="#FFABADB3" BorderThickness="1" Padding="3">
                                        <Border.Background>
                                            <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                                <GradientStop Color="#FFF0F0F0" Offset="0"/>
                                                <GradientStop Color="#FFE5E5E5" Offset="1"/>
                                            </LinearGradientBrush>
                                        </Border.Background>
                                        <StackPanel>
                                            <Calendar x:Name="PART_Calendar" BorderThickness="0" DisplayDate="2016-05-24" Style="{DynamicResource CalendarStyle1}"/>
                                            <xctk:TimePicker x:Name="PART_TimeUpDown" AllowSpin="{TemplateBinding TimePickerAllowSpin}" Background="{DynamicResource {x:Static SystemColors.WindowBrushKey}}" ClipValueToMinMax="{Binding ClipValueToMinMax, RelativeSource={RelativeSource TemplatedParent}}" Foreground="{DynamicResource {x:Static SystemColors.WindowTextBrushKey}}" FormatString="{TemplateBinding TimeFormatString}" Format="{TemplateBinding TimeFormat}" IsUndoEnabled="{Binding IsUndoEnabled, RelativeSource={RelativeSource TemplatedParent}}" Kind="{Binding Kind, RelativeSource={RelativeSource TemplatedParent}}" Maximum="{Binding Maximum, RelativeSource={RelativeSource TemplatedParent}}" Minimum="{Binding Minimum, RelativeSource={RelativeSource TemplatedParent}}" ShowButtonSpinner="{TemplateBinding TimePickerShowButtonSpinner}" Text="" Visibility="{TemplateBinding TimePickerVisibility}" Value="{Binding Value, RelativeSource={RelativeSource TemplatedParent}}" WatermarkTemplate="{TemplateBinding TimeWatermarkTemplate}" Watermark="{TemplateBinding TimeWatermark}"/>
                                        </StackPanel>
                                    </Border>
                                </Popup>
                            </Grid>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="BorderBrush" Value="{DynamicResource {ComponentResourceKey ResourceId=ControlMouseOverBorderKey, TypeInTargetAssembly={x:Type Themes:ResourceKeys}}}"/>
                            </Trigger>
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding IsReadOnly, RelativeSource={RelativeSource Self}}" Value="False"/>
                                    <Condition Binding="{Binding AllowTextInput, RelativeSource={RelativeSource Self}}" Value="False"/>
                                </MultiDataTrigger.Conditions>
                                <Setter Property="IsReadOnly" TargetName="PART_TextBox" Value="True"/>
                            </MultiDataTrigger>
                            <DataTrigger Binding="{Binding IsReadOnly, RelativeSource={RelativeSource Self}}" Value="True">
                                <Setter Property="IsReadOnly" TargetName="PART_TextBox" Value="True"/>
                            </DataTrigger>
                            <Trigger Property="IsKeyboardFocusWithin" Value="True">
                                <Setter Property="BorderBrush" Value="{DynamicResource {ComponentResourceKey ResourceId=ControlSelectedBorderKey, TypeInTargetAssembly={x:Type Themes:ResourceKeys}}}"/>
                            </Trigger>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                            </Trigger>
                            <Trigger Property="IsFocused" Value="True">
                                <Setter Property="FocusManager.FocusedElement" TargetName="PART_TextBox" Value="{Binding ElementName=PART_TextBox}"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="CalendarStyle1" TargetType="{x:Type Calendar}">
            <Setter Property="Foreground" Value="#FF333333"/>
            <Setter Property="Background">
                <Setter.Value>
                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                        <GradientStop Color="#FFE4EAF0" Offset="0"/>
                        <GradientStop Color="#FFECF0F4" Offset="0.16"/>
                        <GradientStop Color="#FFFCFCFD" Offset="0.16"/>
                        <GradientStop Color="#FFFFFFFF" Offset="1"/>
                    </LinearGradientBrush>
                </Setter.Value>
            </Setter>
            <Setter Property="BorderBrush">
                <Setter.Value>
                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                        <GradientStop Color="#FFA3AEB9" Offset="0"/>
                        <GradientStop Color="#FF8399A9" Offset="0.375"/>
                        <GradientStop Color="#FF718597" Offset="0.375"/>
                        <GradientStop Color="#FF617584" Offset="1"/>
                    </LinearGradientBrush>
                </Setter.Value>
            </Setter>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Calendar}">
                        <Viewbox Width="300" Height="300">
                            <StackPanel x:Name="PART_Root" HorizontalAlignment="Center">
                                <CalendarItem x:Name="PART_CalendarItem" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Style="{TemplateBinding CalendarItemStyle}"/>
                            </StackPanel>
                        </Viewbox>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <xctk:DateTimePicker HorizontalAlignment="Center" Margin="0" VerticalAlignment="Center" Style="{DynamicResource DateTimePickerStyle1}"/>
    </Grid>
