     <DataGrid ItemsSource="{Binding Items}" >
            <DataGrid.Resources>
                <local:BindingProxy x:Key="Proxy" Data="{Binding}"/>
            </DataGrid.Resources>
        <DataGrid.Columns>
          <DataGridTextColumn Visibility="{Binding Data.ShowThisColumnFlag, Source={StaticResource Proxy}, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding PropertyOne}" />
	  
          <DataGridTextColumn Visibility="{Binding Data.ShowAnotherColumnFlag, Source={StaticResource Proxy}, Converter={StaticResource BoolToCollapsed}}" Binding="{Binding PropertyTwo}"/>
        </DataGrid.Columns>
     </DataGrid>
