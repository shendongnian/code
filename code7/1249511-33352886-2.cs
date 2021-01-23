    <Style x:Key="TransparentTextBox"
               TargetType="TextBox">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TextBox">
                        <Grid Background="Transparent">
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto" />
                                <RowDefinition Height="*" />
                            </Grid.RowDefinitions>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush"
                                                                           Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                                                        Value="{ThemeResource TextBoxDisabledBorderThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground"
                                                                           Storyboard.TargetName="ContentElement">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                                                        Value="{ThemeResource TextBoxDisabledForegroundThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground"
                                                                           Storyboard.TargetName="PlaceholderTextContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                                                        Value="{ThemeResource TextBoxDisabledForegroundThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground"
                                                                           Storyboard.TargetName="HeaderContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                                                        Value="{ThemeResource TextBoxDisabledHeaderForegroundThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Normal">
                                        <Storyboard>
                                            <DoubleAnimation Duration="0"
                                                             To="{ThemeResource TextControlBorderThemeOpacity}"
                                                             Storyboard.TargetProperty="Opacity"
                                                             Storyboard.TargetName="BorderElement" />
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush"
                                                                           Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                                                        Value="{ThemeResource TextSelectionHighlightColorThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                            <DoubleAnimation Duration="0"
                                                             To="0"
                                                             Storyboard.TargetProperty="Opacity"
                                                             Storyboard.TargetName="PlaceholderTextContentPresenter" />
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border x:Name="BorderElement"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Grid.Row="1" />
                            <ContentPresenter x:Name="HeaderContentPresenter"
                                              ContentTemplate="{TemplateBinding HeaderTemplate}"
                                              Content="{TemplateBinding Header}"
                                              Margin="{ThemeResource TextControlHeaderMarginThemeThickness}"
                                              Grid.Row="0"
                                              Style="{StaticResource HeaderContentPresenterStyle}" />
                            <ScrollViewer x:Name="ContentElement"
                                          AutomationProperties.AccessibilityView="Raw"
                                          HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                          HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                          IsTabStop="False"
                                          IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                          IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                          IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                          Margin="{TemplateBinding BorderThickness}"
                                          MinHeight="{ThemeResource TextControlThemeMinHeight}"
                                          Padding="{TemplateBinding Padding}"
                                          Grid.Row="1"
                                          VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                          VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                          ZoomMode="Disabled" />
                            <ContentControl x:Name="PlaceholderTextContentPresenter"
                                            Content="{TemplateBinding PlaceholderText}"
                                            Foreground="{ThemeResource TextBoxPlaceholderTextThemeBrush}"
                                            FontSize="{ThemeResource ContentControlFontSize}"
                                            IsTabStop="False"
                                            Margin="{TemplateBinding BorderThickness}"
                                            Padding="{TemplateBinding Padding}"
                                            Grid.Row="1" />
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
