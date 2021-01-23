    <Style x:Key="DigitButtonStyle111" TargetType="{x:Type Button}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <Image x:Name="PinButton" Source="pack://application:,,,/V-Coles;component/Resources/Images/pin_key.png" Stretch="Fill"/>
                        <ContentPresenter x:Name="contentPresenter" Focusable="False" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <EventTrigger SourceName="PinButton"  RoutedEvent="Button.PreviewMouseDown">
                            <BeginStoryboard  >
                                <Storyboard >
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PinButton" Storyboard.TargetProperty="Source">
                                        <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="pack://application:,,,/V-Coles;component/Resources/Images/cancle_pin_inpress.png" />
                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <Trigger Property="IsDefaulted" Value="true">
    
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="false">
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Button x:Name="SecondButton" Width="62" Height="63" BorderBrush="Transparent" Style="{StaticResource ButtonStyle11}" PreviewTouchDown="FirstButton_TouchDown" PreviewTouchUp="FirstButton_TouchUp"  PreviewMouseDown="FirstButton_PreviewMouseDown" PreviewMouseUp="FirstButton_PreviewMouseUp" Canvas.Left="72" Canvas.Top="121"  FontWeight="Bold" FontSize="25" Content="2" Command="{Binding Path=DigitButton}" CommandParameter="{Binding ElementName=SecondButton}">
                    <Button.Background>
                        <ImageBrush ImageSource="pack://application:,,,/V-Coles;component/Resources/Images/pin_key.png"/>
                    </Button.Background>
                </Button>
    private void FirstButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        ImageBrush brush1 = new ImageBrush();
        brush1.Stretch = Stretch.Fill;
        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/V;component/Resources/Images/cancle_pin_inpress.png"));
        brush1.ImageSource = image;
        (sender as Button).Background = brush1;
        (sender as Button).Foreground = Brushes.White;
    }
    private void FirstButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        ImageBrush brush1 = new ImageBrush();
        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/V;component/Resources/Images/pin_key.png"));
        brush1.ImageSource = image;
        (sender as Button).Background = brush1;
        (sender as Button).Foreground = Brushes.Black;
    }
    private void FirstButton_TouchDown(object sender, TouchEventArgs e)
    {
        ImageBrush brush1 = new ImageBrush();
        brush1.Stretch = Stretch.Fill;
        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/V;component/Resources/Images/cancle_pin_inpress.png"));
        brush1.ImageSource = image;
        (sender as Button).Background = brush1;
        (sender as Button).Foreground = Brushes.White;
    }
    private void FirstButton_TouchUp(object sender, TouchEventArgs e)
    {
        ImageBrush brush1 = new ImageBrush();
        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/V;component/Resources/Images/pin_key.png"));
        brush1.ImageSource = image;
        (sender as Button).Background = brush1;
        (sender as Button).Foreground = Brushes.Black;
    }
