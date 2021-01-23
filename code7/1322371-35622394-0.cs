    <DataGrid.Columns>
       <DataGridTemplateColumn>
           <DataGridTemplateColumn.CellTemplate>
              <DataTemplate>
                 <Grid>        
                    <Grid.ColumnDefinitions>
                       <ColumnDefinition Width="Auto"/>
                       <ColumnDefinition Width="Auto"/>            
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0" Source="{Binding itemImage}" MaxHeight="20" 
                           MaxWidth="20" />
                    <TextBlock Grid.Column="1" Text="{Binding itemName}"
                                       VerticalAlignment="Center"
                                       Width="Auto"
                                       Margin="5, 0, 0, 0" />
                 </Grid>
             </DataTemplate>
          </DataGridTemplateColumn.CellTemplate>
       </DataGridTemplateColumn>
    </DataGrid.Columns>
