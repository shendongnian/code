                <DataGridTemplateColumn Header="Latest Victory Date" SortMemberPath="LatestVictory">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding LatestVictory, Mode=TwoWay}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <DatePicker SelectedDate="{Binding LatestVictory, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, ConverterCulture='en-GB', StringFormat=d}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
