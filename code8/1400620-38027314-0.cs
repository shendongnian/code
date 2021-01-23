    <Style TargetType="ToggleButton" x:Key="BtnKey">
                <Style.Setters>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type ToggleButton}">
                                <ControlTemplate.Resources>
                                    <Storyboard x:Key="StartAni">
                                        <DoubleAnimation
                                            Storyboard.TargetName="border2"
                                            Storyboard.TargetProperty="StrokeThickness" To="0" Duration="0:0:0.2"/>
                                        <ColorAnimation
                                            Storyboard.TargetName="border2"
                                            Storyboard.TargetProperty="(Shape.Stroke).(SolidColorBrush.Color)" 
                                            To="Red" Duration="0"/>
                                        <DoubleAnimation 
                                               Storyboard.TargetName="border3" 
                                               Storyboard.TargetProperty="StrokeThickness" 
                                               From="0.0" To="5.0" Duration="0"/>
                                    </Storyboard>
    
                                    <Storyboard x:Key="StopAni">
                                        <DoubleAnimation
                                           Storyboard.TargetName="border2"
                                           Storyboard.TargetProperty="StrokeThickness" To="5" Duration="0:0:2.5"/>
                                        <ColorAnimation
                                           Storyboard.TargetName="border2"
                                           Storyboard.TargetProperty="(Shape.Stroke).(SolidColorBrush.Color)" 
                                           To="LightGreen" Duration="0"/>
                                        <DoubleAnimation
                                           Storyboard.TargetName="border3"
                                           Storyboard.TargetProperty="StrokeThickness"
                                           From="5.0" To="0.0" Duration="0:0:0.2"/>
                                    </Storyboard>
    
                                </ControlTemplate.Resources>
                                <Grid>
                                    <Canvas>
                                           
                                        <Ellipse x:Name="border1" Width="100" Height="100" Stroke="Transparent"/>
                                        <Ellipse x:Name="border2" Width="90" Height="90" Stroke="Transparent"/>
                                        <Ellipse x:Name="border3" Width="50" Height="50" Stroke="Transparent"/>
                                    </Canvas>
                                    <ContentPresenter />
                                </Grid>
                                <ControlTemplate.Triggers>
                                    <DataTrigger Binding="{Binding IsDone}" Value="false">
                                        <DataTrigger.EnterActions>
                                            <BeginStoryboard Storyboard="{StaticResource StartAni}">
                                                    
                                            </BeginStoryboard>
                                        </DataTrigger.EnterActions>
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding IsDone}" Value="true">
                                            <DataTrigger.EnterActions>
                                            <BeginStoryboard Storyboard="{StaticResource StopAni}">
                                                
                                            </BeginStoryboard>
                                        </DataTrigger.EnterActions>
                                        </DataTrigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style.Setters>
            </Style>
