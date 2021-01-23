    <DataGrid ItemsSource="{Binding Datasets, NotifyOnTargetUpdated=True}" Name="dsDatagrid" SelectionMode="Extended" MouseDoubleClick="ViewDataset">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="SelectionChanged">
                <cmd:EventToCommand Command="{Binding SelectionChangedCommand}" CommandParameter="{Binding ElementName=dsDatagrid, Path=SelectedItems}"/>
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </DataGrid>
