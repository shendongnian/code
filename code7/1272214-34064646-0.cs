        <DataGrid IsReadOnly="True" AutoGenerateColumns="False" ItemsSource="{Binding Guests}">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Is invited">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding IsInvited}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" IsReadOnly="False"/>
            </DataGrid.Columns>
        </DataGrid>
