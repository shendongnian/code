     <ListView
                ItemsSource="{Binding ParentViewModels, Mode=OneWay}"
                SelectedIndex="{Binding SelectedParentIndex, Mode=TwoWay}"
                SelectedItem="{Binding SelectedParent,Mode=TwoWay}">
    
                <ListView.ItemTemplate>
                    <DataTemplate >
                        <StackPanel>
                            <TextBlock Text="{Binding ParentName}" />
    
                            <ListView                        
                            ItemsSource="{Binding ChildViewModels, Mode=OneWay}"
                            SelectedIndex="{Binding SelectedChildIndex, Mode=TwoWay}"
                            SelectedItem="{Binding SelectedChild,Mode=TwoWay}">   
                            
                                <ListView.ItemTemplate>
                                    <DataTemplate>
    
                                        <TextBlock Text="{Binding ChildName}" />
    
                                    </DataTemplate>
                                </ListView.ItemTemplate>
                            </ListView>
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
