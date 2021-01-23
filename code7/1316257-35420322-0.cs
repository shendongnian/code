    <Style x:Key="MyToggleButtonStyle" TargetType="{x:Type ToggleButton}">
        <Setter Property="FontSize" Value="22" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ToggleButton}">
                    <Grid>
                        <Border Background="#FF0000" />
                        <ContentPresenter x:Name="content" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsPressed"  Value="True" />
                                <Condition Property="IsChecked" Value="False" />
                            </MultiTrigger.Conditions>
                            <Setter Property="FontSize" Value="20" />
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsPressed" Value="False" />
                                <Condition Property="IsChecked" Value="True" />
                            </MultiTrigger.Conditions>
                            <Setter Property="FontSize" Value="17" />
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsPressed" Value="True" />
                                <Condition Property="IsChecked" Value="True" />
                            </MultiTrigger.Conditions>
                            <Setter Property="FontSize" Value="15" />
                        </MultiTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    
    <ToggleButton Style="{StaticResource MyToggleButtonStyle}" Click="ToggleButton_Click">
        <TextBlock x:Name="ToggleButtonLabel" Text="Some Text" />
    </ToggleButton>
