    <Window.Resources>
        <Style x:Key='CellDefaultStyle' TargetType="{x:Type DataGridCell}" >
            <Setter Property="Foreground" Value="Black" />
            <Setter Property="Background" Value="Transparent" />
            <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            <Setter Property="VerticalContentAlignment" Value="Stretch" />
            <Setter Property="Cursor" Value="Arrow" />
            <Setter Property="IsTabStop" Value="False" />
            <Setter Property="Padding" Value="2 5 2 5" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridCell}">
                        <Grid x:Name="Root" Background="{TemplateBinding Background}">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*" />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>
                            <Rectangle x:Name="RightGridLine" VerticalAlignment="Stretch" 
                                       Width="1" Grid.Column="1" />
                            <Rectangle HorizontalAlignment="Stretch" x:Name="FocusVisual" 
                                       VerticalAlignment="Stretch" IsHitTestVisible="false" 
                                       Opacity="0" Fill="Green" Stroke="DarkGreen" 
                                       StrokeThickness="1" Grid.Column="0" />
                            <Rectangle x:Name="BackgroundRectangle" Grid.Column="0" 
                                       Fill="LightSteelBlue" Opacity="0.25" />
                            <Rectangle x:Name="SelectedRectangle" Opacity="0" 
                                       Fill="Blue" Grid.Column="0"  />
                            <Rectangle x:Name="HoverRectangle" 
                                       Fill="LightBlue" Opacity="0" Grid.Column="0"  />
                            <ContentPresenter Grid.Column="0" Margin="{TemplateBinding Padding}" 
                                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}" 
                                              Content="{TemplateBinding Content}" 
                                              ContentTemplate="{TemplateBinding ContentTemplate}" 
                                              Cursor="{TemplateBinding Cursor}"/>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property='Opacity' TargetName='FocusVisual' Value='0.8' />
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" 
                                                                           Storyboard.TargetName="HoverRectangle" 
                                                                           Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="1" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" 
                                                                           Storyboard.TargetName="HoverRectangle" 
                                                                           Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                            <Trigger Property="IsSelected" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="1" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                            <MultiTrigger >
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsMouseOver" Value="True" />
                                    <Condition Property="IsSelected" Value="True" />
                                </MultiTrigger.Conditions>
                                <MultiTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="HoverRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0.5" />
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="1" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.EnterActions>
                                <MultiTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="HoverRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.ExitActions>
                            </MultiTrigger>
                            <MultiTrigger >
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsMouseOver" Value="True" />
                                    <Condition Property="IsSelected" Value="False" />
                                </MultiTrigger.Conditions>
                                <MultiTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="HoverRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="1" />
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.EnterActions>
                                <MultiTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="HoverRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.ExitActions>
                            </MultiTrigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsSelected" Value="True" />
                                    <Condition Property="IsFocused" Value="False" />
                                </MultiTrigger.Conditions>
                                <MultiTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0.6" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.EnterActions>
                                <MultiTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="SelectedRectangle" Storyboard.TargetProperty="(UIElement.Opacity)">
                                                <SplineDoubleKeyFrame KeyTime="00:00:00" Value="0" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.ExitActions>
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="IsSelected" Value="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=DataGridRow}, 
                Path=IsSelected, Mode=OneWayToSource, UpdateSourceTrigger=PropertyChanged}" />
        </Style>
        <Style x:Key='CellReadOnlyStyle' TargetType="{x:Type DataGridCell}" >
             <based on CellDefaultStyle with some minor change in colors ...>
        </Style>
    </Window.Resources>
