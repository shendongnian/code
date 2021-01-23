    <DataGrid xmlns:l="clr-namespace:CSharpWPF">
        <DataGrid.Columns>
            <DataGridComboBoxColumn Header="EnumValues" >
                <DataGridComboBoxColumn.ItemsSource>
                    <Binding>
                        <Binding.Source>
                            <ObjectDataProvider MethodName="GetEnumDescriptions"
                                                ObjectType="{x:Type l:EnumHelper}">
                                <ObjectDataProvider.MethodParameters>
                                    <x:Type TypeName="l:MyTypes" />
                                </ObjectDataProvider.MethodParameters>
                            </ObjectDataProvider>
                        </Binding.Source>
                    </Binding>
                </DataGridComboBoxColumn.ItemsSource>
            </DataGridComboBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
