            <DataGrid Height="294" Width="371" ItemsSource="{Binding ListItems, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" SelectionUnit="Cell" SelectionMode="Single" AutoGenerateColumns="False">
            <DataGridTextColumn Header="Vehical No" Binding="{Binding VehicalNo}" />
            <DataGridTextColumn Header="Model" Binding="{Binding Model}" />
            <DataGridTextColumn Header="ManufacturingDate" Binding="{Binding ManufacturingDate}" />
            <DataGridTextColumn Header="IUNo" Binding="{Binding IUNo}" />
            <DataGridTextColumn Header="Personnel" Binding="{Binding Personnel}" />
        </DataGrid>
