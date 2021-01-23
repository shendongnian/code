        <Grid>
           <Grid.Resources>
             <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}"></FrameworkElement>
           </Grid.Resources>
           <ContentControl Visibility="Collapsed" Content="{StaticResource ProxyElement}"></ContentControl>
           <DataGrid>
               <DataGrid.Columns>
                <DataGridTemplateColumn>
                     <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBox Visibility="{Binding Source={StaticResource ProxyElement}, Path=DataContext.refsub, Converter={StaticResource ConvertorToConvertrefsubToVisibility}}" />
                                </DataTemplate>
                     </DataGridTemplateColumn.CellTemplate>               
                 </DataGridTemplateColumn>
                </DataGrid.Columns>
           </DataGrid>
        </Grid>
