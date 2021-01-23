         <Grid>
            <DataGrid ItemsSource="{Binding customers}" 
          AutoGenerateColumns="False" SelectedItem="{Binding SelectedRow,Mode=TwoWay}"
          CanUserAddRows="False" Grid.Row="1">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding name}" Header="Name"
                                    Width="*"/>
                    
                    <DataGridTemplateColumn Width="Auto" Header="Country">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <ComboBox ItemsSource="{Binding DataContext.countries,
                                    RelativeSource={RelativeSource AncestorType={x:Type Window}}}" 
                                          DisplayMemberPath="name" SelectedValuePath="name" Margin="5" 
                                          SelectedItem="{Binding DataContext.SelectedCountry,RelativeSource={RelativeSource AncestorType={x:Type Window}},Mode=TwoWay}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTextColumn Binding="{Binding phone}" Header="Phone"
                                    Width="*"/>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
