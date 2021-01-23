        <DataGrid x:Name="DGrid" SelectionUnit="FullRow" AutoGenerateColumns="False" ItemsSource="{Binding Students}" Height="400" CanUserAddRows="False" Margin="10,10,405,18">
        
        <DataGrid.Columns>
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Width="100">
                            <Button Content="Edit" Click="Button_Click_1"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal" Width="100">
                            <Button Content="Cancel" Click="Button_Click_2"/>
                            <Button Content="Commit" Click="Button_Click_3"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Name}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Background="Aquamarine" Text="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=Explicit}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
    
        </DataGrid.Columns>
    </DataGrid>
