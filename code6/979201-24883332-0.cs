    <DataGrid ItemsSource="{Binding GroupsCollection}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Col1"
                                IsReadOnly="{Binding IsChecked,
                                             Source={x:Reference DisableColumn1}}" >
            </DataGridTextColumn>
    
            <DataGridTextColumn Header="Col2"
                                IsReadOnly="{Binding IsChecked,
                                             Source={x:Reference DisableColumn2}}" >
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
    
    <GroupBox>
        <StackPanel>
            <RadioButton x:Name="DisableColumn2"
                         Content="Col1 IsReadOnlyFalse, Col2 IsReadOnlyTrue"/>
            <RadioButton x:Name="DisableColumn1"
                         Content="Col1 IsReadOnlyTrue, Col2 IsReadOnlyFalse"/>
        </StackPanel>
    </GroupBox>
