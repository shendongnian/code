     <DataGrid ItemsSource="{Binding Items}" >
        <DataGrid.Columns>
          <DataGridTextColumn Visibility="{Binding ShowThisColumnFlag, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding PropertyOne}" />
	  
          <DataGridTextColumn Visibility="{Binding ShowAnotherColumnFlag, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding PropertyTwo}"/>
        </DataGrid.Columns>
     </DataGrid>
