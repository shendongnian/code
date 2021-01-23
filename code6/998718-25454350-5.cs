    xmlns:local="clr-namespace:WpfApplication1"
    ...
    <Window.Resources>
        <local:SumConverter x:Key="sumConverter"></local:SumConverter>
    </Window.Resources>
    ...
    <GridViewColumn Header="Quantity">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding ShippingHistories,Converter={StaticResource sumConverter},ConverterParameter=Quantity}" />
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
