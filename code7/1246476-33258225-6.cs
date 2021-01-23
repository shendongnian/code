     <DataGridComboBoxColumn x:Name="ComboBoxColumn" Header="Country" DisplayMemberPath="CountryName"
                                        ItemsSource="{StaticResource CountriesArray}" Width="Auto"
                                        SelectedItemBinding="{Binding CountryData, UpdateSourceTrigger=PropertyChanged}">
                    <DataGridComboBoxColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Setter Property="ToolTip">
                                <Setter.Value>
                                    <ContentControl Content="{Binding }">
                                        <ContentControl.ContentTemplate>
                                            <DataTemplate DataType="{x:Type soDataGridProjectsHelpAttempt:UserData}">
                                                <DataTemplate.Resources>
                                                    <system:String x:Key="NoAnyEntriesKey">
                                                        No any entry presented
                                                    </system:String>
                                                </DataTemplate.Resources>
                                                <TextBlock Text="{Binding CountryData.Description, FallbackValue={StaticResource NoAnyEntriesKey}}"></TextBlock>
                                            </DataTemplate>
                                        </ContentControl.ContentTemplate>
                                    </ContentControl>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </DataGridComboBoxColumn.CellStyle>
                </DataGridComboBoxColumn>
