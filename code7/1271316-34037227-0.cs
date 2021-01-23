    <Grid>
       <Grid.Resources>
           <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}"/>
       </Grid.Resources>
           <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"></ContentControl>
           <DataGrid x:Name="dataGridsupplier" 
                           ItemsSource="{Binding Collection}" 
                           AutoGenerateColumns="False">
              <DataGrid.Columns>
                  <DataGridTextColumn Header="Full Company Name" Binding="{Binding fullCompanyName, UpdateSourceTrigger=PropertyChanged}" Width="*"/>
                  <DataGridComboBoxColumn Header="Payment Method" 
                                          ItemsSource="{Binding DataContext.Method, Source={StaticResource ProxyElement}}"
                                          SelectedItemBinding="{Binding methodOfPayment}"/>
              </DataGrid.Columns>
         </DataGrid>
    </Grid>
