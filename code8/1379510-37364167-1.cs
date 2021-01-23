                <DataGridTemplateColumn Header="Project Name">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox Name="cbProjects" DataContext="{Binding}" ItemsSource="{Binding Project}" SelectedItem="{Binding Projects}" SelectionChanged="OnMyComboBoxChanged" >
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Allocation">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Name="tbAllocation" DataContext="{Binding SelectedProjects}" Text="{Binding AllocationPercentage"></TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
