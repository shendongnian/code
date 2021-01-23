    <UserControl x:Class="SGDB.UI.Controls.ModernButton"
         xmlns:local="clr-namespace:SGDB.UI.Controls"
         xmlns:converter="clr-namespace:SGDB.UI.Converter"
         x:Name="_modernButton">
                 
        <UserControl.Template>
            <ControlTemplate TargetType="UserControl">
                <Button Content="{TemplateBinding Content}">
                     <Button.Resources>
                        <converter:EnumToColorConverter x:Key="ColorConverter"/>
                      </Button.Resources>
                <Button.Template >
                    <ControlTemplate TargetType="Button">
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
    </UserControl>
