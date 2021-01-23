    <DataGrid AutoGenerateColumns="False" x:Name="myGrid">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Product, Mode=TwoWay}" Header="Product name"/>
            <DataGridComboBoxColumn Width="100" x:Name="Operation" 
                SelectedValueBinding="{Binding Operation, Mode=TwoWay}" Header="Operation" 
                DisplayMemberPath="{Binding Operation}"  >
            </DataGridComboBoxColumn>
            <DataGridComboBoxColumn Width="100" x:Name="Quality" 
                SelectedValueBinding="{Binding Quality, Mode=TwoWay}" Header="Qualità" 
                DisplayMemberPath="{Binding Quality}" />
            <DataGridTextColumn Binding="{Binding Cost, Mode=TwoWay}" Header="Cost"/>
        </DataGrid.Columns>
    </DataGrid>
