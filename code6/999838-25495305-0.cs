    <sdk:DataGrid ItemsSource="{Binding items}" SelectedItem="{Binding selItem, Mode=TwoWay}">
       <sdk:DataGrid.Columns>
           <sdk:DataGridTemplateColumn Width="*">
               <sdk:DataGridTemplateColumn.CellTemplate>
                   <DataTemplate>
                       <View:leadDataTemplate item="{Binding .}"/>
                   </DataTemplate>
               </sdk:DataGridTemplateColumn.CellTemplate>
           </sdk:DataGridTemplateColumn>
       </sdk:DataGrid.Columns>
    </sdk:DataGrid>
