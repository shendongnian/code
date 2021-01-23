    <Grid>
        <Grid.Resources>
            <Style x:Key="ToggleButtonStyle" TargetType="{x:Type ToggleButton}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ToggleButton}">
                            <Border HorizontalAlignment="Center" VerticalAlignment="Center" x:Name="border" Background="Red">
                                <ContentPresenter/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsChecked" Value="true">
                                    <Setter Property="Background" TargetName="border" Value="Green"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
    
        <ToggleButton Content="ToggleButton" Style="{StaticResource ToggleButtonStyle}"/>
    </Grid>
