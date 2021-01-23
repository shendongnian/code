    <!-- Default style for Windows.UI.Xaml.Controls.ToggleMenuFlyoutItem -->
    <Style TargetType="ToggleMenuFlyoutItem">
      <Setter Property="Background" Value="Transparent" />
      <Setter Property="Padding" Value="{ThemeResource MenuFlyoutItemThemePadding}" />
      <Setter Property="HorizontalContentAlignment" Value="Left" />
      <Setter Property="VerticalContentAlignment" Value="Center" />
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="ToggleMenuFlyoutItem">
            <Border x:Name="LayoutRoot" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}"
                    BorderThickness="{TemplateBinding BorderThickness}">
              <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                  <VisualState x:Name="Normal" />
                  <VisualState x:Name="PointerOver" />
                  <VisualState x:Name="Pressed">
                    <Storyboard>
                      <PointerDownThemeAnimation Storyboard.TargetName="InnerBorder" />
                    </Storyboard>
                  </VisualState>
                  <VisualState x:Name="Disabled">
                    <Storyboard>
                      <ObjectAnimationUsingKeyFrames Storyboard.TargetName="TextBlock" Storyboard.TargetProperty="Foreground">
                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource MenuFlyoutItemDisabledForegroundThemeBrush}" />
                      </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                  </VisualState>
                  <VisualStateGroup.Transitions>
                    <VisualTransition From="Pressed" To="PointerOver">
                      <Storyboard>
                        <PointerUpThemeAnimation Storyboard.TargetName="InnerBorder" />
                      </Storyboard>
                    </VisualTransition>
                    <VisualTransition From="PointerOver" To="Normal">
                      <Storyboard>
                        <PointerUpThemeAnimation Storyboard.TargetName="InnerBorder" />
                      </Storyboard>
                    </VisualTransition>
                    <VisualTransition From="Pressed" To="Normal">
                      <Storyboard>
                        <PointerUpThemeAnimation Storyboard.TargetName="InnerBorder" />
                      </Storyboard>
                    </VisualTransition>
                  </VisualStateGroup.Transitions>
                </VisualStateGroup>
              </VisualStateManager.VisualStateGroups>
              <Border x:Name="InnerBorder" Padding="{TemplateBinding Padding}">
                <TextBlock x:Name="TextBlock"
                           Text="{TemplateBinding Text}"
                           HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                           VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
              </Border>
            </Border>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
