       <DataGrid Name="DataGridView1" ItemsSource="{Binding Models}" AutoGenerateColumns="False" Margin="176,70,409,92" SelectionChanged="DataGridView1_SelectionChanged" >
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Id}" Header="#"/>
                    <DataGridTextColumn Binding="{Binding Value}" Header="Client Name"/>
                </DataGrid.Columns>
            </DataGrid>
