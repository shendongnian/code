    <DataGrid ItemsSource="{Binding Employees}" AutoGenerateColumns="False" CanUserAddRows="False" >
            <DataGrid.Columns>
                <DataGridTemplateColumn >
                    <DataGridTemplateColumn.Header>
                        <CheckBox x:Name="chkSelectAll">
                            <i:Interaction.Triggers>
                                <i:EventTrigger  EventName="Click">
                                    <i:InvokeCommandAction Command="{Binding Path = DataContext.SelectAllCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=DataGrid,AncestorLevel=1}}" 
                                                           CommandParameter="{Binding ElementName=chkSelectAll, Path=IsChecked, UpdateSourceTrigger=PropertyChanged}"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </CheckBox>
                    </DataGridTemplateColumn.Header>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                                <i:Interaction.Triggers>
                                    <i:EventTrigger  EventName="Unchecked">
                                        <local:EventTriggerPropertySetAction TargetObject="{Binding ElementName=chkSelectAll}" PropertyName="IsChecked" PropertyValue="False"/>
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                            </CheckBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
    
                </DataGridTemplateColumn>
                <DataGridTextColumn Binding="{Binding Id}" Header="Id"/>
                <DataGridTextColumn Binding="{Binding Name, UpdateSourceTrigger=PropertyChanged}" Header="Name"/>
                <DataGridTextColumn Binding="{Binding Salary, UpdateSourceTrigger=PropertyChanged}" Header="Salary"/>
            </DataGrid.Columns>
    </DataGrid>
