    <DataGrid Grid.Column="0" AutoGenerateColumns="False" CanUserAddRows="False" ItemsSource="{Binding ItemNamesSetting}" SelectedItem="{Binding VMPropertyName}" >
          <DataGrid.Columns >
              <DataGridTextColumn Header="Item1" Binding="{Binding Path=OriginalItemName}" />
              <DataGridTextColumn Header="Item2" Binding="{Binding Path=FinalItemName}" />                                        
              <DataGridTemplateColumn Header="Attribute">
                                            <DataGridTemplateColumn.CellTemplate>
                  <DataTemplate>
                      <ComboBox ItemsSource="{Binding DataContext.AttributesBindingList, ElementName=ThirdStepTab}" DisplayMemberPath="PropName" SelectedValue="{Binding PropertyOfVM}"  />
                   </DataTemplate>                           </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
              <DataGridTextColumn Header="Item3" Binding="{Binding Path=Separatopr}" />
