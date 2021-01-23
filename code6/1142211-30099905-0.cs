       <Grid Margin="10">
            <DataGrid ItemsSource="{Binding EntityList}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Id" Binding="{Binding Id}" />
                    <DataGridTextColumn Header="Last Name" Binding="{Binding LastName}" />
                    <DataGridTextColumn Header="First Name" Binding="{Binding FirstName}" />
                    <DataGridTextColumn Header="Middle Name" Binding="{Binding MiddleName}" />
                    <DataGridCheckBoxColumn Header="Status" Binding="{Binding StatusId}" />
                </DataGrid.Columns>
               
            </DataGrid>
        </Grid>
