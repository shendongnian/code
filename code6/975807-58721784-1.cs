     <DataGrid ItemsSource="{Binding Items}" >
        <DataGrid.Columns>
          <DataGridTextColumn Visibility="{Binding ShowThisColumnFlag, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding _authenticationMode}"></DataGridTextColumn>
	  
          <DataGridTextColumn Visibility="{Binding _Binding ShowAnotherColumnFlag, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding _wpaPersonalKeyAC}"/>
        </DataGrid.Columns>
     </DataGrid>
