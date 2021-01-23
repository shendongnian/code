     <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <chartingToolkit:Chart x:Name="LineChart" Title="Demo Chart">
            <chartingToolkit:LineSeries  DependentValuePath="Value" DataPointStyle="{StaticResource DataPointStyle}" IndependentValuePath="Key" ItemsSource="{Binding}"  IsSelectionEnabled="True">
                <chartingToolkit:LineSeries.Resources>
                    <SolidColorBrush x:Key="ChartLineColor" Color="Green"/>
                </chartingToolkit:LineSeries.Resources>
            </chartingToolkit:LineSeries>
        </chartingToolkit:Chart>
        <chartingToolkit:Chart x:Name="LineChart1" Grid.Column="1" Title="Demo Chart">
            <chartingToolkit:LineSeries  DependentValuePath="Value" DataPointStyle="{StaticResource DataPointStyle}" IndependentValuePath="Key" ItemsSource="{Binding}"  IsSelectionEnabled="True">
                <chartingToolkit:LineSeries.Resources>
                    <SolidColorBrush x:Key="ChartLineColor" Color="Red"/>
                </chartingToolkit:LineSeries.Resources>
            </chartingToolkit:LineSeries>
        </chartingToolkit:Chart>
    </Grid>
