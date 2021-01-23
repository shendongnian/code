    <sdk:DataGrid AutoGenerateColumns="False" Padding="15" Height="129" x:Name="dgSOF" Width="1021" ItemsSource="{Binding Path=TestListBinding}" RowHeight="30" BorderBrush="#FFE4E4E4">
                <sdk:DataGrid.Columns>
                    <sdk:DataGridTextColumn Binding="{Binding Path=Something}" Header="Something"/>
                    <sdk:DataGridTemplateColumn>
                        <sdk:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Button Margin="5" Click="Button_Click" Width="100" Content="Click Me!"/>
                            </DataTemplate>
                        </sdk:DataGridTemplateColumn.CellTemplate>
                    </sdk:DataGridTemplateColumn>
                </sdk:DataGrid.Columns>
            </sdk:DataGrid>
