        <UserControl.Resources>
        <Style x:Key="SliderRepeatButton" TargetType="RepeatButton">                       
            <Setter Property="Focusable" Value="false" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="RepeatButton">
                        <Border Height="10">
                            <Border.Background>
                                <ImageBrush ImageSource="darblue_tab.png"></ImageBrush>
                            </Border.Background>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="SliderRepeatButton1" TargetType="RepeatButton">
            <Setter Property="Focusable" Value="false" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="RepeatButton">
                        <Border SnapsToDevicePixels="True" Background="Green"   Height="10"/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key="SliderThumb" TargetType="Thumb">
            <Setter Property="Focusable" Value="false" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Thumb">
                        <Ellipse Height="20" Width="20">
                            <Ellipse.Fill>
                                <ImageBrush ImageSource="darblue_tab.png"></ImageBrush>
                            </Ellipse.Fill>
                        </Ellipse>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <ControlTemplate x:Key="Slider"  TargetType="Slider">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition Height="Auto" MinHeight="{TemplateBinding MinHeight}" />
                    <RowDefinition Height="Auto" />
                </Grid.RowDefinitions>
                <Track Grid.Row="1" x:Name="PART_Track"   >
                    <Track.DecreaseRepeatButton>
                        <RepeatButton Style="{StaticResource SliderRepeatButton1}"  Command="Slider.DecreaseLarge" />
                    </Track.DecreaseRepeatButton>
                    <Track.Thumb>
                        <Thumb Style="{StaticResource SliderThumb}"  />
                    </Track.Thumb>
                    <Track.IncreaseRepeatButton>
                        <RepeatButton Style="{StaticResource SliderRepeatButton}" Command="Slider.IncreaseLarge" />
                    </Track.IncreaseRepeatButton>
                </Track>
            </Grid>
        </ControlTemplate>
        <Style x:Key="Horizontal_Slider" TargetType="Slider">
            <Setter Property="Focusable" Value="False"/>       
            <Style.Triggers>
                <Trigger Property="Orientation" Value="Horizontal">                   
                    <Setter Property="Template" Value="{StaticResource Slider}" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
    <Slider Style="{StaticResource Horizontal_Slider}" VerticalAlignment="Center"  Value="500" Width="300" Margin="50,0,50,0"></Slider>
