    <ControlTemplate x:Key="BtnTemplate" TargetType="{x:Type Button}">
        <Grid Background="Transparent">
            <ContentPresenter x:Name="contentPresenter" HorizontalAlignment="Center" VerticalAlignment="Center"/>
        </Grid>
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="FontWeight" Value="SemiBold"/>
            </Trigger>
            <Trigger Property="IsEnabled" Value="False">
                <Setter Property="Foreground" Value="Gray" />
            </Trigger>
        </ControlTemplate.Triggers>
        <ControlTemplate.Resources>
            <Style TargetType="{x:Type Image}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsMouseOver, RelativeSource={RelativeSource AncestorType=Button}}" Value="True">
                        <DataTrigger.Setters>
                            <Setter Property="Effect">
                                <Setter.Value>
                                    <DropShadowEffect BlurRadius="20" Color="Black" ShadowDepth="0" Opacity="0.5"/>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger.Setters>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsPressed, RelativeSource={RelativeSource AncestorType=Button}}" Value="True">
                        <DataTrigger.Setters>
                            <Setter Property="Effect">
                                <Setter.Value>
                                    <DropShadowEffect BlurRadius="20" Color="Black" ShadowDepth="0" Opacity="1" />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger.Setters>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ControlTemplate.Resources>
    </ControlTemplate>
