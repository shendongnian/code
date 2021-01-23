        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.Resources>
            <Color x:Key="AppErrorColor">#FFD32F2F</Color>
            <SolidColorBrush x:Key="ThemeErrorShade" Color="{ThemeResource AppErrorColor}" />
            <Style x:Key="SearchBoxStyle" TargetType="SearchBox">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="SearchBox">
                            <Grid x:Name="SearchBoxGrid">
                                ...
                                
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="SearchBoxGrid">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding Background, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="SearchBoxBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding BorderBrush, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="SearchButton">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding Foreground, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="SearchBoxGrid">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SearchBoxDisabledBackgroundThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="SearchBoxBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SearchBoxDisabledBorderThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="SearchButton">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SearchBoxDisabledTextThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="SearchTextBox">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="Transparent"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="ErrorStates">
                                        <VisualState x:Name="TextInvalid">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="SearchBoxGrid">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ThemeErrorShade}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="TextValid">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="SearchBoxGrid">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding Background, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="SearchBoxBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding BorderBrush, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="SearchButton">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{Binding Foreground, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                
                                ...
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        
        <SearchBox Style="{StaticResource SearchBoxStyle}">
            <interactivity:Interaction.Behaviors>
                <core:EventTriggerBehavior EventName="Loaded">
                    <core:EventTriggerBehavior.Actions>
                        <actions:SearchBoxTextErrorVisualStateAction ErrorVisualState="TextInvalid" ValidVisualState="TextValid" />
                    </core:EventTriggerBehavior.Actions>
                </core:EventTriggerBehavior>
                <core:EventTriggerBehavior EventName="QueryChanged">
                    <core:EventTriggerBehavior.Actions>
                        <actions:SearchBoxTextErrorVisualStateAction ErrorVisualState="TextInvalid" ValidVisualState="TextValid" />
                    </core:EventTriggerBehavior.Actions>
                </core:EventTriggerBehavior>
            </interactivity:Interaction.Behaviors>
        </SearchBox>
    </Grid>
