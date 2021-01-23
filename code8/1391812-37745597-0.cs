                               <PivotItem>
                                  <Pivot.Header>
                                    <ListView ItemsSource="{Binding TestList}">
                                        <ListView.ItemTemplate>
                                            <DataTemplate>
                                             <TextBlock Text="{Binding SMenu}"/>
                                            </DataTemplate>
                                        </ListView.ItemTemplate>                                        
                                    </ListView>   
                                  </Pivot.Header>  
                               </PivotItem>
