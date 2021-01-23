    <Grid Background="White" x:Name="Layout">
        <DataGrid x:Name="grid" ItemsSource="{Binding MyCollection}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding FirstName}">
                    <DataGridTextColumn.Header>
                        <TextBlock DataContext="{Binding ElementName=Layout, Path=DataContext}" Text="{Binding Header1}"/>
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
