                <Style Key="RightButtonStyle" TargetType="Button">
                    <Setter Property="OverridesDefaultStyle" Value="True"/>
                    <Setter Property="Margin" Value="5"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="Button">
                                <Border Name="border" 
                                        BorderThickness="1"
                                        Padding="4,2" 
                                        BorderBrush="DarkGray" 
                                        CornerRadius="3" 
                                        Background="{TemplateBinding Background}">
                                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter TargetName="border" Property="BorderBrush" Value="Black" />
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="BlueViolet"></Setter>
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="False">
                            <Setter Property="Background" Value="Yellow" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
