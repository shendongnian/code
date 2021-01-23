    <Style x:Key="HalfBorderTextBoxStyle" TargetType="TextBox">
        <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}" />
        <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}" />
        <Setter Property="MinWidth" Value="{ThemeResource TextControlThemeMinWidth}" />
        <Setter Property="MinHeight" Value="{ThemeResource TextControlThemeMinHeight}" />
        <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Hidden" />
        <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Hidden" />
        <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False" />
        <Setter Property="BorderThickness" Value="0,0,0,2" />
        <Setter Property="Padding" Value="8,5" />
        <Setter Property="Foreground">
            <Setter.Value>
                <SolidColorBrush Color="White" />
            </Setter.Value>
        </Setter>
        <Setter Property="Background">
            <Setter.Value>
                <SolidColorBrush Color="Transparent" />
            </Setter.Value>
        </Setter>
        <Setter Property="BorderBrush">
            <Setter.Value>
                <SolidColorBrush Color="#FF8FBE19" />
            </Setter.Value>
        </Setter>
        <Setter Property="SelectionHighlightColor">
            <Setter.Value>
                <SolidColorBrush Color="#FF8FBE19" />
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="TextBox">
                    <Grid>
                        <Grid.Resources>
                            <Style x:Name="DeleteButtonStyle" TargetType="Button">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="Button">
                                            <Grid x:Name="ButtonLayoutGrid" BorderBrush="{ThemeResource TextBoxButtonBorderThemeBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{ThemeResource TextBoxButtonBackgroundThemeBrush}">
                                                <VisualStateManager.VisualStateGroups>
                                                    <VisualStateGroup x:Name="CommonStates">
                                                        <VisualState x:Name="Normal" />
                                                        <VisualState x:Name="PointerOver">
                                                            <Storyboard>
                                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="GlyphElement">
                                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAccentBrush}" />
                                                                </ObjectAnimationUsingKeyFrames>
                                                            </Storyboard>
                                                        </VisualState>
                                                        <VisualState x:Name="Pressed">
                                                            <Storyboard>
                                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="ButtonLayoutGrid">
                                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAccentBrush}" />
                                                                </ObjectAnimationUsingKeyFrames>
                                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="GlyphElement">
                                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltChromeWhiteBrush}" />
                                                                </ObjectAnimationUsingKeyFrames>
                                                            </Storyboard>
                                                        </VisualState>
                                                        <VisualState x:Name="Disabled">
                                                            <Storyboard>
                                                                <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ButtonLayoutGrid" />
                                                            </Storyboard>
                                                        </VisualState>
                                                    </VisualStateGroup>
                                                </VisualStateManager.VisualStateGroups>
                                                <TextBlock x:Name="GlyphElement" AutomationProperties.AccessibilityView="Raw" Foreground="{ThemeResource SystemControlForegroundChromeBlackMediumBrush}" FontStyle="Normal" FontSize="12" FontFamily="{ThemeResource SymbolThemeFontFamily}" HorizontalAlignment="Center" Text="&#xE10A;" VerticalAlignment="Center" />
                                            </Grid>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </Grid.Resources>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="Auto" />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition GeneratedDuration="0:0:0.2" To="Focused">
                                        <VisualTransition.GeneratedEasingFunction>
                                            <ExponentialEase EasingMode="EaseIn" />
                                        </VisualTransition.GeneratedEasingFunction>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2" To="1.4" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Storyboard.TargetName="LeftVerticalLine" d:IsOptimized="True" />
                                            <DoubleAnimation Duration="0:0:0.2" To="1.4" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Storyboard.TargetName="RightVerticalLine" d:IsOptimized="True" />
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition From="Focused" GeneratedDuration="0:0:0.2">
                                        <VisualTransition.GeneratedEasingFunction>
                                            <ExponentialEase EasingMode="EaseOut" />
                                        </VisualTransition.GeneratedEasingFunction>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:0.2" To="1" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Storyboard.TargetName="LeftVerticalLine" d:IsOptimized="True" />
                                            <DoubleAnimation Duration="0:0:0.2" To="1" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Storyboard.TargetName="RightVerticalLine" d:IsOptimized="True" />
                                        </Storyboard>
                                    </VisualTransition>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Disabled">
                                    <VisualState.Setters>
                                        <Setter Target="BorderElement.(UIElement.Opacity)" Value="1" />
                                    </VisualState.Setters>
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="HeaderContentPresenter">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseLowBrush}" />
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="BottomLine">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseLowBrush}" />
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentElement">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledChromeDisabledLowBrush}" />
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Normal" />
                                <VisualState x:Name="PointerOver" />
                                <VisualState x:Name="Focused">
                                    <VisualState.Setters>
                                        <Setter Target="LeftVerticalLine.(UIElement.Opacity)" Value="1" />
                                        <Setter Target="RightVerticalLine.(UIElement.Opacity)" Value="1" />
                                        <Setter Target="LeftVerticalLine.(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Value="1.4" />
                                        <Setter Target="RightVerticalLine.(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Value="1.4" />
                                    </VisualState.Setters>
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Opacity" Storyboard.TargetName="BackgroundElement">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundFocusedOpacity}" />
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="ButtonStates">
                                <VisualState x:Name="ButtonVisible">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DeleteButton">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="ButtonCollapsed" />
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Border x:Name="BackgroundElement" Background="{TemplateBinding Background}" Grid.ColumnSpan="2" Margin="{TemplateBinding BorderThickness}" Opacity="{ThemeResource TextControlBackgroundRestOpacity}" Grid.Row="1" Grid.RowSpan="1" />
                        <Rectangle x:Name="BottomLine" Grid.ColumnSpan="2" Grid.Row="1" Grid.RowSpan="1" VerticalAlignment="Bottom" Height="2" Fill="{TemplateBinding BorderBrush}" />
                        <Rectangle x:Name="LeftVerticalLine" HorizontalAlignment="Left" Height="4" Margin="0,0,0,2" Grid.Row="1" Stretch="Fill" UseLayoutRounding="True" VerticalAlignment="Bottom" Width="2" RenderTransformOrigin="0.5,1" Fill="{TemplateBinding BorderBrush}">
                            <Rectangle.RenderTransform>
                                <CompositeTransform />
                            </Rectangle.RenderTransform>
                        </Rectangle>
                        <Rectangle x:Name="RightVerticalLine" HorizontalAlignment="Right" Height="4" Margin="0,0,0,2" Grid.Row="1" Stretch="Fill" UseLayoutRounding="True" VerticalAlignment="Bottom" Width="2" RenderTransformOrigin="0.5,1" Grid.ColumnSpan="2" Fill="{TemplateBinding BorderBrush}">
                            <Rectangle.RenderTransform>
                                <CompositeTransform />
                            </Rectangle.RenderTransform>
                        </Rectangle>
                        <ContentPresenter x:Name="HeaderContentPresenter" Grid.ColumnSpan="2" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" Foreground="{ThemeResource SystemControlForegroundBaseHighBrush}" FontWeight="Normal" Margin="0,0,0,8" Grid.Row="0" Visibility="Collapsed" x:DeferLoadStrategy="Lazy" />
                        <ScrollViewer x:Name="ContentElement" AutomationProperties.AccessibilityView="Raw" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsTabStop="False" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="Disabled" />
                        <ContentControl x:Name="PlaceholderTextContentPresenter" Grid.ColumnSpan="2" Content="{TemplateBinding PlaceholderText}" Foreground="{ThemeResource ButtonBackgroundThemeBrush}" IsHitTestVisible="False" IsTabStop="False" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1" />
                        <Button x:Name="DeleteButton" BorderThickness="{TemplateBinding BorderThickness}" Grid.Column="1" FontSize="{TemplateBinding FontSize}" IsTabStop="False" Margin="{ThemeResource HelperButtonThemePadding}" MinWidth="34" Grid.Row="1" Style="{StaticResource DeleteButtonStyle}" Visibility="Collapsed" VerticalAlignment="Stretch" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
