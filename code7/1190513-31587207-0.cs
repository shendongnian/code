    <!--Standard brushes-->
    <ImageBrush x:Key="BrushBtnIdle">
        <ImageBrush.ImageSource>
            <BitmapImage>
                <BitmapImage.UriSource>
                    <system1:Uri>pack://application:,,,/AssemblyName;component/Resources/Images/Btn_Idle.png
                    </system1:Uri>
                </BitmapImage.UriSource>
            </BitmapImage>
        </ImageBrush.ImageSource>
    </ImageBrush>
    <ImageBrush x:Key="BrushBtnPushed">
        <ImageBrush.ImageSource>
            <BitmapImage>
                <BitmapImage.UriSource>
                    <system1:Uri>pack://application:,,,/AssemblyName;component/Resources/Images/Btn_Pushed.png
                    </system1:Uri>
                </BitmapImage.UriSource>
            </BitmapImage>
        </ImageBrush.ImageSource>
    </ImageBrush>
    <Style TargetType="{x:Type local:MyParentClass}">
        <Setter Property="Background" Value="White"/>
        <Setter Property="BorderThickness" Value="1"/>
        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
        <Setter Property="HorizontalContentAlignment" Value="Center"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:MyParentClass}">
                    
                    <Border Background="{TemplateBinding Background}"
                            Margin="{TemplateBinding Margin}"
                            BorderBrush="{TemplateBinding BorderBrush}" 
                            SnapsToDevicePixels="true"
                            Opacity="{TemplateBinding Opacity}"
                            CornerRadius="{TemplateBinding Border.CornerRadius}" 
                            Padding="{TemplateBinding Padding}">
                        <ContentPresenter  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                           Margin="{TemplateBinding Padding}" 
                                           RecognizesAccessKey="True" 
                                           SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                                           VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsPressed" Value="True">
                <Setter Property="Background" Value="{StaticResource BrushBtnPushed}"/>
            </Trigger>
            <Trigger Property="IsPressed" Value="False">
                <Setter Property="Background" Value="{StaticResource BrushBtnIdle}"/>
            </Trigger>
            <Trigger Property="IsEnabled" Value="False">
                <Setter Property="Opacity" Value=".5"/>
            </Trigger>
        </Style.Triggers>
    </Style>
    <!--Highlighted button-->
    <ImageBrush x:Key="BrushBtnHighlight">
        <ImageBrush.ImageSource>
            <BitmapImage>
                <BitmapImage.UriSource>
                    <system1:Uri>pack://application:,,,/AssemblyName;component/Resources/Images/ActivatedBtn.png
                    </system1:Uri>
                </BitmapImage.UriSource>
            </BitmapImage>
        </ImageBrush.ImageSource>
    </ImageBrush>
    <Style TargetType="{x:Type local:MyChildrenClass}" BasedOn="{StaticResource {x:Type local:MyParentClass}}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding RelativeSource={RelativeSource self}, Path=IsPressed}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard TargetProperty="Background">
                            <ObjectAnimationUsingKeyFrames Duration="00:00:01" FillBehavior="Stop">
                                <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="{StaticResource BrushBtnHighlight}"/>
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
