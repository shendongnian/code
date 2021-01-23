    <StackPanel>
        <StackPanel.Resources>
            <Style x:Key="stlNavButtonBorder" TargetType="Border">
                <Setter Property="BorderBrush" Value="#570000FF" />
                <Setter Property="BorderThickness" Value="5" />
                <Setter Property="Height" Value="100" />
                <Setter Property="Width" Value="200" />
                <Setter Property="Margin" Value="10" />
            </Style>
            <Style x:Key="stlNavButtonRectangle" TargetType="Rectangle">
                <Setter Property="Fill" Value="#570000FF"/>
            </Style>
            <Style TargetType="Button">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <Border Style="{StaticResource stlNavButtonBorder}" x:Name="border">
                                <Grid>
                                    <Rectangle Style="{StaticResource stlNavButtonRectangle}"/>
                                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                </Grid>
                            </Border>
                            <ControlTemplate.Triggers>                               
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Trigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="border"
                                                    Storyboard.TargetProperty="BorderBrush.Color"
                                                    To="Blue"
                                                    Duration="0:0:0.25"/>               
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.EnterActions>
                                    <Trigger.ExitActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="border"
                                                    Storyboard.TargetProperty="BorderBrush.Color"
                                                    To="#570000FF"
                                                    Duration="0:0:0.25"/>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.ExitActions>
                                </Trigger>
                                <Trigger Property="IsPressed" Value="True">
                                    <Trigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="border"
                                                    Storyboard.TargetProperty="BorderBrush.Color"
                                                    To="Black"
                                                    Duration="0:0:0.25" />
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.EnterActions>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>                        
                    </Setter.Value>
                </Setter>
            </Style>
        </StackPanel.Resources>
        <Button Content="Button 1" />
        <Button Content="Button 2"/>
        <Button Content="Button 3" />
    </StackPanel>
