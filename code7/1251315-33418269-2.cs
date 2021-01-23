    <Window.Resources>
        <Style TargetType="ToggleButton">
            <Setter Property="BorderThickness" Value="1" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ToggleButton">
                        <Border Name="border" Background="Transparent" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="Black">
                            <ContentPresenter/>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsChecked" Value="True">
                    <Setter Property="BorderThickness" Value="10" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <ToggleButton>Hello World</ToggleButton>
    </Grid>
   
