    <Grid>
      <Grid.Resources>
               <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}"/>
       </Grid.Resources>
       <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"></ContentControl>
        <DataGrid x:Name="datagrid" Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding Alvm.Artists}">
          <DataGrid.Columns>
            <DataGridTextColumn Header="ID" IsReadOnly="True" Binding="{Binding Id}" />
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
            <DataGridTextColumn Header="Email" Binding="{Binding Email}" />
            <DataGridComboBoxColumn Header="Category" SelectedItemBinding="{Binding Category}"
                                    ItemsSource="{Binding DataContext.Clvm.Categories, Source={StaticResource ProxyElement}}" />
          </DataGrid.Columns>
        </DataGrid>     
    </Grid>
