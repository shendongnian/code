            <ImageBrush x:Key="CheckedBullet" ImageSource="MyResources/Koala.jpg"/>
        <ImageBrush x:Key="UnCheckedBullet" ImageSource="MyResources/Penguins.jpg"/>
        <Style x:Key="RadioBtnToolStyle" TargetType="{x:Type RadioButton}">
            <Setter Property="Background" Value="#00FFFFFF" />
            <Setter Property="HorizontalAlignment" Value="Center" />
            <Setter Property="Foreground" Value="{x:Null}" />
            <Setter Property="Padding" Value="0" />
            <Setter Property="Margin" Value="3" />
            <Setter Property="BorderBrush" Value="{x:Null}" />
            <Setter Property="OverridesDefaultStyle" Value="True" />
            <Setter Property="RenderTransform">
                <Setter.Value>
                    <ScaleTransform CenterX="30" CenterY="30" ScaleX="1" ScaleY="1" />
                </Setter.Value>
            </Setter>
            <Setter Property="Cursor" Value="Hand" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="RadioButton">
                        <Border Name="border" BorderThickness="0" BorderBrush="Black" Background="{TemplateBinding Background}">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Opacity" Value="0.8" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsPressed" Value="True">
                    <Trigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation From="1" To="0.8" AutoReverse="False" Duration="00:00:00.6" Storyboard.TargetProperty="RenderTransform.ScaleX" />
                                <DoubleAnimation From="1" To="0.8" AutoReverse="False" Duration="00:00:00.6" Storyboard.TargetProperty="RenderTransform.ScaleY" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.EnterActions>
                    <Trigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation To="1" Duration="00:00:00.6" Storyboard.TargetProperty="RenderTransform.ScaleX" />
                                <DoubleAnimation To="1" Duration="00:00:00.6" Storyboard.TargetProperty="RenderTransform.ScaleY" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.ExitActions>
                </Trigger>
            </Style.Triggers>
        </Style>
            <!--code that use the style above-->
        <RadioButton GroupName="Tools"  Grid.Row="0" IsChecked="{Binding IsBrightnessAndContrastEnabled, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" HorizontalAlignment="Right" VerticalAlignment="Bottom">
            <RadioButton.Style>
                <Style TargetType="RadioButton" BasedOn="{StaticResource RadioBtnToolStyle}">
                    <Setter Property="Width" Value="50"></Setter>
                    <Setter Property="Height" Value="50"></Setter>
                    <Style.Triggers>
                        <Trigger Property="IsChecked" Value="True">
                            <Setter Property="Content" Value="{StaticResource InvertImageBtn}" />
                        </Trigger>
                        <Trigger Property="IsChecked" Value="False">
                            <Setter Property="Content" Value="{StaticResource  LogoFooterBackgroundStyle}" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </RadioButton.Style>
        </RadioButton>
    </Grid>
