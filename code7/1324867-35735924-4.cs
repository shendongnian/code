    <Style TargetType="{x:Type local:AwareTabItem}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:AwareTabItem}">
                    <Grid Name="Panel" Background="Transparent">
                        <Border Name="ContentBorder" BorderBrush="#FFD4D4D4" BorderThickness="0">
                            <ContentPresenter x:Name="ContentSite"
                                              VerticalAlignment="Center" Effect="{x:Null}"
                                              HorizontalAlignment="Center"
                                              ContentSource="Header" Margin="10,2"/>
                        </Border>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True" SourceName="Panel">
                            <Setter Property="Foreground" Value="#FF2B579A" />
                            <Setter Property="Background" Value="#FFFAFAFA" />
                        </Trigger>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter TargetName="Panel" Property="Background" Value="#FFFAFAFA" />
                            <Setter Property="Foreground" Value="#FF2B579A" />
                            <Setter TargetName="ContentBorder" Property="BorderThickness" Value="1,1,1,0" />
                        </Trigger>
                        <!--When ExtendChrome, !IsDark, !IsSelected-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="False"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsSelect}" Value="False"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Foreground" Value="#FF000000"/>
                            <Setter TargetName="ContentBorder" Property="Background">
                                <Setter.Value>
                                    <RadialGradientBrush>
                                        <GradientStop Color="#9AFFFFFF" Offset="0"/>
                                        <GradientStop Color="#90FFFFFF" Offset="0.4"/>
                                        <GradientStop Offset="1"/>
                                    </RadialGradientBrush>
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <!--When ExtendChrome, !IsDark, IsMouseOver-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="False"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsMouseOver}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Foreground" Value="#FF2B579A"/>
                        </MultiDataTrigger>
                        <!--When ExtendChrome, !IsDark, IsSelected-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="False"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsSelected}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter TargetName="Panel" Property="Background" Value="#FFFAFAFA" />
                            <Setter Property="Foreground" Value="#FF2B579A" />
                            <Setter TargetName="ContentBorder" Property="BorderThickness" Value="1,1,1,0" />
                        </MultiDataTrigger>
                        <!--When ExtendChrome, IsDark, !IsSelected-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsSelected}" Value="False"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Foreground" Value="#FFF8F8FF"/>
                            <Setter TargetName="ContentBorder" Property="Background">
                                <Setter.Value>
                                    <RadialGradientBrush>
                                        <GradientStop Color="{Binding Source={x:Static SystemParameters.WindowGlassColor}, 
                                                      Converter={StaticResource ColorToAlphaConverter}, ConverterParameter=6E}" Offset="0"/>
                                        <GradientStop Color="{Binding Source={x:Static SystemParameters.WindowGlassColor}, 
                                                      Converter={StaticResource ColorToAlphaConverter}, ConverterParameter=50}" Offset="0.4"/>
                                        <GradientStop Offset="1"/>
                                    </RadialGradientBrush>
                                </Setter.Value>
                            </Setter>
                        </MultiDataTrigger>
                        <!--When ExtendChrome, IsDark, IsMouseOver-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsMouseOver}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Foreground" Value="#FFBFEFFF"/>
                        </MultiDataTrigger>
                        
                        <!--When ExtendChrome, IsDark, IsSelected-->
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Source={x:Static prop:Settings.Default}, Path=EditorExtendChrome, FallbackValue=False}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsDark}" Value="True"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsSelected}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter TargetName="Panel" Property="Background" Value="#FFFAFAFA" />
                            <Setter Property="Foreground" Value="#FF2B579A" />
                            <Setter TargetName="ContentBorder" Property="BorderThickness" Value="1,1,1,0" />
                        </MultiDataTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <!--Default Values-->
        <Setter Property="FontFamily" Value="Segoe UI Semilight"/>
    </Style>
