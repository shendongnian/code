    <ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:WpfApplication5">
    <Style TargetType="{x:Type local:SlideGrid}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:SlideGrid}">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="ViewStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition GeneratedDuration="0:0:0.3" To="Expanded">
                                        <Storyboard>
                                            <DoubleAnimation x:Name="VSExpandedX" Storyboard.TargetName="FlipButtonTransform" Storyboard.TargetProperty="X" To="0" Duration="0:0:0.3"></DoubleAnimation>
                                            <DoubleAnimation x:Name="VSExpandedY" Storyboard.TargetName="FlipButtonTransform" Storyboard.TargetProperty="Y" To="0" Duration="0:0:0.3"></DoubleAnimation>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition GeneratedDuration="0:0:0.3" To="Closed">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="FlipButtonTransform" Storyboard.TargetProperty="X" To="-300" Duration="0:0:0.3"></DoubleAnimation>
                                        </Storyboard>
                                    </VisualTransition>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Closed">
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetName="ExpandedState" 
                                                             Storyboard.TargetProperty="Opacity" 
                                                             To="0" 
                                                             Duration="0" ></DoubleAnimation>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Expanded">
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetName="ClosedState" 
                                                             Storyboard.TargetProperty="Opacity" 
                                                             To="0" 
                                                             Duration="0" ></DoubleAnimation>
                                        <DoubleAnimation Storyboard.TargetName="FlipButtonTransform"
                                                         Storyboard.TargetProperty="X"  
                                                         To="0" 
                                                         Duration="0"></DoubleAnimation>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <!-- This is the Closed content. -->
                        <ContentPresenter x:Name="ClosedState"  Content="{TemplateBinding ClosedState}">
                        </ContentPresenter>
                        <!-- This is the Expanded content. -->
                        <ContentPresenter x:Name="ExpandedState" Content="{TemplateBinding ExpandedState}">
                            <ContentPresenter.RenderTransform>
                                <TranslateTransform x:Name="FlipButtonTransform" X="-300" Y="0"></TranslateTransform>
                            </ContentPresenter.RenderTransform>
                        </ContentPresenter>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
