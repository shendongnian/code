    <Grid>
       <Grid.Resources>
           <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}"/>
       </Grid.Resources>
           <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"></ContentControl>
           <DataGrid  
                           ItemsSource="{Binding Collection}" 
                           AutoGenerateColumns="False">
              <DataGrid.Columns>
                  <DataGridTextColumn Header="{Binding DataContext.MyProperty, Source={StaticResource ProxyElement}}" Binding="{Binding PropertyName}" />
              </DataGrid.Columns>
         </DataGrid>
    </Grid>
