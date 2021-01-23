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
            FontFamily="Arial" 
            CellEditEnding="dataGridParametros_CellEditEnding" >
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding IdParametro}" Header="Id" FontFamily="Arial" IsReadOnly="True" Visibility="Hidden"/>
        <DataGridTextColumn Binding="{Binding Codigo}" Header="Código" FontFamily="Arial" IsReadOnly="True"/>
        <DataGridTextColumn Width="200" Binding="{Binding Mnemonico}" Header="Mnemonico" FontFamily="Arial" IsReadOnly="True" />
        <DataGridTextColumn Width="250*" Binding="{Binding Descricao}" Header="Descrição" FontFamily="Arial" IsReadOnly="True" />
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
                                                    <CheckBox IsChecked="{Binding Valor , Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}"/>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding TipoCampo}" Value="ComboBox">
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <ComboBox ItemsSource="{Binding Valor , Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}" />
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </DataTrigger>
                                    <DataTrigger Binding="{Binding TipoCampo}" Value="TextBox">
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <TextBox Text="{Binding Valor , Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}" />
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
