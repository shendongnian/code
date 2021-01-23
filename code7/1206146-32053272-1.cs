    <ControlTemplate TargetType="Button">
        <Border TextBlock.Foreground="{TemplateBinding Foreground}"
                x:Name="Border"
                CornerRadius="2"
                BorderThickness="1">
          <VisualStateManager.VisualStateGroups>
              <VisualState x:Name="Disabled">
                <Storyboard>
                  <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).
                      (GradientBrush.GradientStops)[1].(GradientStop.Color)"
                                                Storyboard.TargetName="Border">
                    <EasingColorKeyFrame KeyTime="0"
                                         Value="{StaticResource DisabledControlDarkColor}" />
                  </ColorAnimationUsingKeyFrames>
                  <ColorAnimationUsingKeyFrames
                      Storyboard.TargetProperty="(TextBlock.Foreground).(SolidColorBrush.Color)"
                                                Storyboard.TargetName="Border">
                    <EasingColorKeyFrame KeyTime="0"
                                         Value="{StaticResource DisabledForegroundColor}" />
                  </ColorAnimationUsingKeyFrames>
                  <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Border.BorderBrush).
                      (GradientBrush.GradientStops)[1].(GradientStop.Color)"
                                                Storyboard.TargetName="Border">
                    <EasingColorKeyFrame KeyTime="0"
                                         Value="{StaticResource DisabledBorderDarkColor}" />
                  </ColorAnimationUsingKeyFrames>
                </Storyboard>
              </VisualState>
            </VisualStateGroup>
          </VisualStateManager.VisualStateGroups>
          <ContentPresenter Margin="2"
                            HorizontalAlignment="Center"
                            VerticalAlignment="Center"
                            RecognizesAccessKey="True" />
        </Border>
    </ControlTemplate>
