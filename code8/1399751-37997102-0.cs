     <Window x:Class="ChkList_Learning.Window4"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:ChkList_Learning"
            xmlns:sys="clr-namespace:System;assembly=mscorlib"
            mc:Ignorable="d"
            Title="Window4" Height="300" Width="300">
        <Window.Resources>
            <local:Temp x:Key="temp" Value="{Binding ElementName=Hostname, Path=Watermark}"/>
            <Style TargetType="{x:Type local:WatermarkTextBox}" BasedOn="{StaticResource {x:Type TextBox}}">
                <Style.Resources>
                    <VisualBrush x:Key="WatermarkBrush" AlignmentX="Left" AlignmentY="Center" Stretch="None">
                        <VisualBrush.Visual>
                            <TextBlock Text="{Binding Source={StaticResource temp}, Path=Value}" FontFamily="Segoe UI" FontSize="20" Foreground="LightGray" Padding="5" />
                        </VisualBrush.Visual>
                    </VisualBrush>
                </Style.Resources>
                <Style.Triggers>
                    <Trigger Property="Text" Value="{x:Static sys:String.Empty}">
                        <Setter Property="Background" Value="{StaticResource WatermarkBrush}" />
                    </Trigger>
                    <Trigger Property="Text" Value="{x:Null}">
                        <Setter Property="Background" Value="{StaticResource WatermarkBrush}" />
                    </Trigger>
                    <Trigger Property="IsKeyboardFocused" Value="True">
                        <Setter Property="Background" Value="White" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        <Grid>
            <local:WatermarkTextBox x:Name="Hostname" Height="40" FontFamily="Segoe UI" FontSize="20" VerticalContentAlignment="Center" Watermark="Hello, world.">
    
            </local:WatermarkTextBox>
        </Grid>
    </Window>
    
         public class Temp : Freezable
            {
        
                // Dependency Property
                public static readonly DependencyProperty ValueProperty =
                     DependencyProperty.Register("Value", typeof(string),
                     typeof(Temp), new FrameworkPropertyMetadata(string.Empty));
        
                // .NET Property wrapper
                public string Value
                {
                    get { return (string)GetValue(ValueProperty); }
                    set { SetValue(ValueProperty, value); }
                }
        
                protected override System.Windows.Freezable CreateInstanceCore()
                {
                    return new Temp();
                }
            }
     public class WatermarkTextBox : TextBox
        {
            static WatermarkTextBox()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
            }
    
            public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(string), typeof(WatermarkTextBox));
    
            public string Watermark
            {
                get { return (string)GetValue(WatermarkProperty); }
                set { SetValue(WatermarkProperty, value); }
            }
        }
