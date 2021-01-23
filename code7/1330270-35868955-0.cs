    <DataGrid ItemsSource="{Binding Countries}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Country" Binding="{Binding Name}"/>
        </DataGrid.Columns>
        <DataGrid.RowHeaderTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding DataContext.Continent, 
                            RelativeSource={RelativeSource AncestorType=DataGridRow}}"></TextBlock>
            </DataTemplate>
        </DataGrid.RowHeaderTemplate>
    </DataGrid>
