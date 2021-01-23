        <DataGrid Name="Persons" ItemsSource="{Binding}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="First name"  Binding="{Binding FirstName}"/>
                <DataGridTextColumn Header="Last name" Binding="{Binding LastName}"/>
                <DataGridCheckBoxColumn Header="Alive" Binding="{Binding Alive}"/>
            </DataGrid.Columns>
        </DataGrid>
