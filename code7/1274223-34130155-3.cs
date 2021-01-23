    <DataTemplate x:Key="MenuItemTemplate">
            <Button Content="{StaticResource image1}" Height="30" Width="100">
                <Button.Style>
                    <Style TargetType="Button">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="Button">
                                    <Grid>
                                        <Border x:Name="Border" Height="{TemplateBinding Height}"
                                            Width="{TemplateBinding Width}" Background="Orange">
                                        </Border>
                                        <ContentPresenter ContentSource="Content" HorizontalAlignment="Stretch" VerticalAlignment="Top"/>
                                    </Grid>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsFocused" Value="True">
                                            <Setter Property="RenderTransform"  TargetName="Border">
                                                <Setter.Value>
                                                    <ScaleTransform CenterX="0.5" CenterY="0.5" ScaleX="1" ScaleY="1.2"></ScaleTransform>
                                                </Setter.Value>
                                            </Setter>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                        <Style.Triggers>
                            
                        </Style.Triggers>
                    </Style>
                </Button.Style>
            </Button>
        </DataTemplate>
