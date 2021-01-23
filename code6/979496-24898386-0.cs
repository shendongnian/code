    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup Name="CommonStates">
                                <VisualState Name="Normal"/>
                                <VisualState Name="MouseOver">
                                    <Storyboard>
                                        <DoubleAnimation
                                            Storyboard.TargetName="image1"
                                            Storyboard.TargetProperty="Opacity"
                                            To="0" Duration="0:0:0.1"/>
                                        <DoubleAnimation
                                            Storyboard.TargetName="image2"
                                            Storyboard.TargetProperty="Opacity"
                                            To="1" Duration="0:0:0.1"/>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Image x:Name="image1">
                            <Image.Source>
                                <BitmapImage UriSource="{Binding Content,
                                    RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                            </Image.Source>
                        </Image>
                        <Image x:Name="image2" Opacity="0">
                            <Image.Source>
                                <BitmapImage UriSource="{Binding Tag,
                                    RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                            </Image.Source>
                        </Image>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
