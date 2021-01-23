    <Window.Resources>
        <wpfApplication12:NumericToAlphaConverter x:Key="NumericToAlphaConverter"/>
    </Window.Resources>
    <Grid>
        <chartingToolkit:Chart   Title="Line Series"  
		VerticalAlignment="Top" Margin="0" Height="254" >
            <chartingToolkit:LineSeries  x:Name="serie"
                                       IndependentValueBinding="{Binding Path=Key}"
                                       DependentValueBinding="{Binding Path=Value}"		 
		IsSelectionEnabled="True"/>
            <chartingToolkit:Chart.Axes>
                <chartingToolkit:LinearAxis Orientation="Y" 
                                        Title="Y val" 
                                            Maximum="5"
                                            Minimum="1"
                                            >
                    <chartingToolkit:LinearAxis.AxisLabelStyle>
                        <Style TargetType="chartingToolkit:AxisLabel">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="chartingToolkit:AxisLabel">
                                        <TextBlock DataContext="{TemplateBinding FormattedContent}" Text="{Binding Converter={StaticResource NumericToAlphaConverter}}" />
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </chartingToolkit:LinearAxis.AxisLabelStyle>
                </chartingToolkit:LinearAxis>
            </chartingToolkit:Chart.Axes>
        </chartingToolkit:Chart>
    </Grid>
