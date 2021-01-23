      <UserControl.Template>
            <ControlTemplate TargetType="{x:Type UserControl}">
                <Button Content="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content}">
                    <Button.Resources>
                       <converter:EnumToColorConverter x:Key="ColorConverter"/>
                    </Button.Resources>
                    <Button.Template>
                        <ControlTemplate>
                            <Border Width="{Binding Size,
                                            ElementName=_modernButton}"
                            Height="{Binding Size,
                                             ElementName=_modernButton}"
                            BorderBrush="Black"
                            BorderThickness="0.8,0.8,3,3">
                                <Grid Background="{Binding BackgroundColor, ElementName=_modernButton, Converter={StaticResource ColorConverter}}">
                                    <ContentPresenter />
                                </Grid>
                            </Border>
                        </ControlTemplate>
                    </Button.Template>
                </Button>
            </ControlTemplate>
        </UserControl.Template>
