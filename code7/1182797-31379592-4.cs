    <DataTemplate x:Key="SingleParameterColumn">       
        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Cells}"      
                  RowHeight="25" RowHeaderWidth="0">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.HeaderTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="Auto" />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*"
                                                   SharedSizeGroup="DataGridHeaderRow" />
                                </Grid.RowDefinitions>
                                <TextBlock Text="{Binding Name}"
                                           TextWrapping="Wrap"
                                           TextAlignment="Center"
                                           MaxWidth="60">
                                </TextBlock>
                                <Button Grid.Column="1">
                                    <Image ... />
                                </Button>
                            </Grid>
                        </DataTemplate>
                    </DataGridTemplateColumn.HeaderTemplate>
                    <DataGridTemplateColumn.CellTemplateSelector>....
                    </DataGridTemplateColumn.CellTemplateSelector>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </DataTemplate>
