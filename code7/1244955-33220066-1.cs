     <Grid>
           <Grid.Resources>
               <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}"></FrameworkElement>
           </Grid.Resources>
           <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"></ContentControl>
           <DataGrid>
               <DataGrid.Columns>
                    <DataGridTextColumn Visibility="{Binding Source={StaticResource ProxyElement}, Path=DataContext._ViewPurchasePrices, Converter={StaticResource BoolToVisibilityConverter}}"></DataGridTextColumn>
                    </DataGrid.Columns>
           </DataGrid>
        </Grid>
