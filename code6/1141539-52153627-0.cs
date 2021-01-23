    <DataGrid x:Name="dataGridParametros"
                Grid.Row="1"
                Margin="5"
                AutoGenerateColumns="False"
                HeadersVisibility="All"
                ItemsSource="{Binding}"
                RowHeaderWidth="20"
                SelectionUnit="FullRow"
                ScrollViewer.CanContentScroll="True" 
                CanUserAddRows="false"
                ScrollViewer.VerticalScrollBarVisibility="Auto"
                ScrollViewer.HorizontalScrollBarVisibility="Auto" 
                FontFamily="Arial" >
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Codigo}" Header="Código" FontFamily="Arial" />
            <DataGridTextColumn Width="200" Binding="{Binding Mnemonico}" Header="Mnemonico" FontFamily="Arial" />
            <DataGridTextColumn Width="250*" Binding="{Binding Descricao}" Header="Descrição" FontFamily="Arial" />
            <DataGridTemplateColumn Header="Valor" Width="150">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ContentControl Content="{Binding}">
                            <ContentControl.Style>
                                <Style TargetType="ContentControl">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding TipoCampo}" Value="CheckBox">
                                            <Setter Property="ContentTemplate">
                                                <Setter.Value>
                                                    <DataTemplate>
                                                        <CheckBox IsChecked="{Binding Valor }"/>
                                                    </DataTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding TipoCampo}" Value="ComboBox">
                                            <Setter Property="ContentTemplate">
                                                <Setter.Value>
                                                    <DataTemplate>
                                                        <ComboBox ItemsSource="{Binding Valor}" />
                                                    </DataTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding TipoCampo}" Value="TextBox">
                                            <Setter Property="ContentTemplate">
                                                <Setter.Value>
                                                    <DataTemplate>
                                                        <TextBox Text="{Binding Valor}" />
                                                    </DataTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ContentControl.Style>
                        </ContentControl>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
