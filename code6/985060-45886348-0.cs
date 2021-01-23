            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <Border Background="DarkGray" Padding="20,4,4,4">
                    <DataGrid ItemsSource="{Binding MyDetailsList}" AutoGenerateColumns="False"  Background="Transparent">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="Col 1" Binding="{Binding Field1}" />
                            <DataGridTextColumn Header="Col 2" Binding="{Binding Field2, StringFormat=0.000}"  />
                            <DataGridTextColumn Header="Col 3" /> 
                            <DataGridTextColumn Header="Col 4" Binding="{Binding Field3}" />
                        </DataGrid.Columns>
                    </DataGrid>
                    </Border>
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
