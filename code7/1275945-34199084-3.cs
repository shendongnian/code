           <ToggleButton IsChecked="{Binding IsBrightnessAndContrastEnabled, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" HorizontalAlignment="Left" VerticalAlignment="Top">
            <ToggleButton.Style>
                <Style TargetType="ToggleButton" BasedOn="{StaticResource SpecialButtonStyle}">
                    <Setter Property="Width" Value="50"></Setter>
                    <Setter Property="Height" Value="50"></Setter>
                    <Style.Triggers>
                        <Trigger Property="IsChecked" Value="True">
                            <Setter Property="Content" Value="{StaticResource InvertImageBtn2}" />
                        </Trigger>
                        <Trigger Property="IsChecked" Value="False">
                            <Setter Property="Content" Value="{StaticResource  LogoFooterBackgroundStyle2}" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </ToggleButton.Style>
        </ToggleButton>
