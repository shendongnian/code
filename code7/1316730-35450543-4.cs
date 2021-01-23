                    <telerik:GridViewDataColumn Width="150" DataMemberBinding="{Binding Path=StackOptimizerSelectedRule}"
                                            Header="Rules"
                                            IsFilterable="False" IsReorderable="False">
                    <telerik:GridViewDataColumn.CellTemplate>
                        <DataTemplate DataType="flowConfiguration:StackOptimizerParameterRuleTreeViewModel">
                            <TextBlock Text="{Binding StackOptimizerSelectedRule, UpdateSourceTrigger=PropertyChanged, Converter={StaticResource EnumTypeConverterKey}}"></TextBlock>
                        </DataTemplate>
                    </telerik:GridViewDataColumn.CellTemplate>
                    
                    <telerik:GridViewDataColumn.CellEditTemplate>
                        <DataTemplate DataType="flowConfiguration:StackOptimizerParameterRuleTreeViewModel">
                            <ComboBox 
                                ItemsSource="{Binding Source={StaticResource StackOptimizerSelectionRules}}"
                                SelectedItem="{Binding StackOptimizerSelectedRule, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                                <ComboBox.ItemTemplate>
                                    <DataTemplate DataType="flowConfiguration:StackOptimizerParameterRuleTreeViewModel">
                                        <TextBlock Text="{Binding Converter={StaticResource EnumTypeConverterKey}, UpdateSourceTrigger=PropertyChanged}"/>
                                    </DataTemplate>
                                </ComboBox.ItemTemplate>
                            </ComboBox>
                        </DataTemplate>
                    </telerik:GridViewDataColumn.CellEditTemplate>
                </telerik:GridViewDataColumn>
