    <Window ...
            xmlns:Microsoft_Windows_Themes="clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero"
    >
        <Window.Resources>
            <Style TargetType="RadioButton" >
                <Setter Property="Template" >
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type RadioButton}">
                            <DockPanel Background="Transparent" >
                                <Microsoft_Windows_Themes:BulletChrome DockPanel.Dock="Bottom" HorizontalAlignment="Center"
                                                                       IsRound="true" Height="{TemplateBinding FontSize}" Width="{TemplateBinding FontSize}" 
                                                                       BorderBrush="{TemplateBinding BorderBrush}" Background="{TemplateBinding Background}" 
                                                                       IsChecked="{TemplateBinding IsChecked}" 
                                                                       RenderMouseOver="{TemplateBinding IsMouseOver}" RenderPressed="{TemplateBinding IsPressed}" />
                                <ContentPresenter RecognizesAccessKey="True" 
                                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}" 
                                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" />
                            </DockPanel>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsEnabled" Value="False" >
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
        <StackPanel Orientation="Horizontal" >
            <RadioButton>
                <Image Source="..." />
            </RadioButton>
            <RadioButton>
                <Image Source="..." />
            </RadioButton>
            <RadioButton>
                <Image Source="..." />
            </RadioButton>
        </StackPanel>
    </Window>
