    <Window.Resources>
        <Style x:Key="EllipseStyle1"  TargetType="{x:Type Ellipse}">
            <Setter Property="Fill" Value="Green"></Setter>
            <Setter Property="Height" Value="16"></Setter>
            <Setter Property="Width" Value="16"></Setter>
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="true">
                    <Setter Property="Fill" Value="Red"></Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
        
        <Style x:Key="LineDataPointStyle1" TargetType="{x:Type chartingToolkit:LineDataPoint}">
            <Setter Property="Background" Value="Blue"></Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="chartingToolkit:LineDataPoint">
                        <Canvas>
                            <Ellipse Style="{DynamicResource EllipseStyle1}">
                            </Ellipse>
                        </Canvas>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    
    <Grid>
        <chartingToolkit:Chart Margin="0" Title="Chart Title">
            <chartingToolkit:Chart.DataContext>
                <PointCollection>1,10 2,20 3,30 4,40</PointCollection>
            </chartingToolkit:Chart.DataContext>
            <chartingToolkit:LineSeries DependentValuePath="Y" IndependentValuePath="X" 
                                        ItemsSource="{Binding}" 
                                        DataPointStyle="{DynamicResource LineDataPointStyle1}" />
        </chartingToolkit:Chart>
    </Grid>
