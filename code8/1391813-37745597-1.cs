                               <PivotItem>
                                  <PivotItem.Header>
                                    <ListView ItemsSource="{Binding TestList}">
                                        <ListView.ItemTemplate>
                                            <DataTemplate>
                                             <TextBlock Text="{Binding SMenu}"/>
                                            </DataTemplate>
                                        </ListView.ItemTemplate>                                        
                                    </ListView>   
                                  </PivotItem.Header>  
                               </PivotItem>
