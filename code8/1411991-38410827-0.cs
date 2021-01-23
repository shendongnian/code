    <Window ...>
        <Window.Resources>       
            <ItemsPanelTemplate x:Key="ItemsPanelTemplate1">
                <DataGridRowsPresenter x:Name="PART_RowsPresenter" IsItemsHost="True" Orientation="Horizontal"/>
            </ItemsPanelTemplate>
    
            <DataTemplate x:Key="DetailsKey">
              <StackPanel DataContext="{Binding SelectedMovie}">
                <TextBlock Height="50" Background="Red" Text="{Binding SourcePath}"/>
                <TextBlock Height="50" Background="Red" Text="{Binding ID}"/>
              </StackPanel>
             </DataTemplate>
        </Window.Resources>
        <Grid>
    
            <DataGrid x:Name="Dgrd" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Sets}" RowDetailsTemplate="{StaticResource DetailsKey}">
    
                                    <DataGrid.Columns>
                                        <DataGridTemplateColumn>
                                            <DataGridTemplateColumn.CellTemplate>
                                                <DataTemplate>
                                                    <DataGrid ItemsSource="{Binding MovieImageList}" SelectedItem="{Binding SelectedMovie, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ItemsPanel="{DynamicResource ItemsPanelTemplate1}" AutoGenerateColumns="False">                                                    
                                                        <DataGrid.Columns>
                                                            <DataGridTemplateColumn>
                                                                <DataGridTemplateColumn.CellTemplate>
                                                                    <DataTemplate>
                                                                        <Image Source="{Binding SourcePath}" Width="50" Height="50"/>
                                                                    </DataTemplate>
                                                                </DataGridTemplateColumn.CellTemplate>
                                                            </DataGridTemplateColumn>
                                                        </DataGrid.Columns>
                                                    </DataGrid>
                                                </DataTemplate>
                                            </DataGridTemplateColumn.CellTemplate>
                                        </DataGridTemplateColumn>
                                    </DataGrid.Columns>
                                </DataGrid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
            
            
        </Grid>
    </Window>
