        <DataGrid ItemsSource="{Binding Times}"
                  SelectionMode="Single"
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Department">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path= Department.DepartmentCode}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox ItemsSource="{Binding RelativeSource={RelativeSource Findancestor, AncestorType={x:Type UserControl}}, Path=DataContext.Departments, UpdateSourceTrigger=PropertyChanged}"
                                      DisplayMemberPath="DepartmentCode"
                                      SelectedValuePath="DepartmentCode"
                                      SelectedValue="{Binding Department.DepartmentCode}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Job code">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path=Job}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox SelectedValue="{Binding Job}">
                                <ComboBox.ItemsSource>
                                    <MultiBinding Converter="{StaticResource DepartmentJobComboboValueConverter}">
                                        <Binding Path="Department" />
                                        <Binding Path="DataContext.JobCodes"
                                                 RelativeSource="{RelativeSource Findancestor, AncestorType={x:Type UserControl}}"/>
                                    </MultiBinding>
                                </ComboBox.ItemsSource>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
