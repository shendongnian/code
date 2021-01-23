     <DataGrid  ItemsSource="{Binding}" Name="dgvProcessLists" SelectionMode="Single">\
    <DataGrid.Columns><DataGridTextColumn Binding="{Binding SIZE_FP}" FontFamily="Verdana" Header="SIZE FP" IsReadOnly="True" Width="100" />
    <DataGridTemplateColumn Width="140" Header="Command">
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button Content="{Binding  DB_STEP_NAME}" Tag="{Binding STEP_ORDER}" Click="btnContinue_Click" >
                                            <Button.Style>
                                                <Style x:Name="ButtonVisibility">
                                                    <Setter Property="Button.Visibility" Value="Hidden"/>
                                                    <Style.Triggers>
                                                        <DataTrigger Binding="{Binding STATUS}" Value="Failed">
                                                            <Setter Property="Button.Visibility" Value="Visible"/>
                                                            <Setter Property="Button.Background" Value="#777777"/>
                                                        </DataTrigger>
                                                        <DataTrigger Binding="{Binding STATUS}" Value="Execute">
                                                            <Setter Property="Button.Visibility" Value="Visible"/>
                                                            <Setter Property="Button.Background" Value="AliceBlue"/>
                                                        </DataTrigger>
                                                        <DataTrigger Binding="{Binding STATUS}" Value="Re-Evaluate">
                                                            <Setter Property="Button.Background" Value="Blue"/>
                                                        </DataTrigger>                                                    
                                                        <DataTrigger Binding="{Binding STATUS}" Value="Final">
                                                            <Setter Property="Button.Visibility" Value="Visible"/>
                                                            <Setter Property="Button.Background" Value="Blue"/>
                                                        </DataTrigger>
                                                    </Style.Triggers>
                                                </Style>
                                            </Button.Style>
                                        </Button>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                                </DataGrid.Columns>
    </Datagrid>
    
    
   
    
