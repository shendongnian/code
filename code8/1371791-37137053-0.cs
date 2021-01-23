    <UserControl x:Class="ButtonLikeInSO.SpecialTextPresenterWithButton"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d" 
             d:DesignHeight="300" d:DesignWidth="150" x:Name="This">
    <UserControl.Resources>
        <SolidColorBrush x:Key="GrayButtonBackGround" Color="Gainsboro"/>
        <SolidColorBrush x:Key="RedButtonBackground" Color="Tomato"/>
        <Style x:Key="ChangeContentOnMouseOverWithAnimationWhenPressed" TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
            <Setter Property="Background" Value="{StaticResource GrayButtonBackGround}"/>
            <Setter Property="Foreground" Value="Black"></Setter>
            <Setter Property="ToolTip" Value="Delete Uploading"/>
            <Setter Property="ToolTipService.Placement" Value="Top"/>
            <Setter Property="Opacity" Value="0.8"></Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Grid x:Name="LayoutRoot" RenderTransformOrigin="0.5 0.5" Margin="2">
                            <Grid.RenderTransform>
                                <ScaleTransform></ScaleTransform>
                            </Grid.RenderTransform>
                            <Ellipse x:Name="MyBorder" Fill="{TemplateBinding Background}" Stroke="Gray" StrokeThickness="1"/>
                            <Ellipse x:Name="RectangleVisibleOnMouseMove" Opacity="0" Fill="{StaticResource RedButtonBackground}" Stroke="Black" StrokeThickness="1"/>
                            <Path x:Name="ButtonPath"
                                  Margin="5"
                                  Stroke="{TemplateBinding Foreground}"
                                  StrokeThickness="1.5"
                                  StrokeStartLineCap="Square"
                                  StrokeEndLineCap="Square"
                                  Stretch="Uniform"
                                  VerticalAlignment="Center"
                                  HorizontalAlignment="Center" Data="M0,0 L1,1 M0,1 L1,0">
                            </Path>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <EventTrigger RoutedEvent="Button.MouseEnter">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnMouseMove" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MyBorder" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.MouseLeave">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnMouseMove" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MyBorder" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.PreviewMouseDown">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleX)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="0.8" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleY)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="0.8" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.PreviewMouseUp">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleX)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.8" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleY)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.8" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="Button.IsPressed" Value="True">
                    <Setter Property="Foreground" Value="White"></Setter>
                </Trigger>
                <Trigger Property="IsPressed" Value="False">
                    <Setter Property="Foreground" Value="Black"></Setter>
                </Trigger>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Opacity" Value="1.0"></Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
        <DataTemplate x:Key="TextWithDeleteButton">
            <Border BorderThickness="1" BorderBrush="Gainsboro">
                <Grid Background="{Binding ElementName=This, Path=Background}">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="5*"/>
                        <ColumnDefinition Width="30"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding ElementName=This, Path=Text}" MaxWidth="150" Margin="5,0,0,0" HorizontalAlignment="Left" VerticalAlignment="Center"
                               TextTrimming="WordEllipsis" />
                    <Button Grid.Column="1" Margin="0" Width="20" Height="20" HorizontalAlignment="Center" VerticalAlignment="Center" Command="{Binding ElementName=This, Path=DeleteCommand}" Style="{StaticResource ChangeContentOnMouseOverWithAnimationWhenPressed}"></Button>
                </Grid>
            </Border>
        </DataTemplate>
        </UserControl.Resources>
        <Grid>
            <ContentControl ContentTemplate="{StaticResource TextWithDeleteButton}"></ContentControl>
        </Grid>
