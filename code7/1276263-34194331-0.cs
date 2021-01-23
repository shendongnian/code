    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Source=TableResult}" >
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Name" Binding="{Binding col1}"/>
                    <DataGridTextColumn Header="Surname" Binding="{Binding col2}"/>
                    <DataGridTextColumn Header="Phone" Binding="{Binding col3}" />
                </DataGrid.Columns>
     </DataGrid>
