            <ItemsControl ItemsSource="{Binding MyViewModelCollection}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel Orientation="Horizontal"/>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <ContentControl Content="{Binding}">
                            <ContentControl.Resources>
                               <ResourceDictionary>
                                 <DataTemplate DataType="{x:Type myNameSpace:myViewModel1}">
                                    <myNameSpace:myControl2/>
                                 </DataTemplate>
                                 <DataTemplate DataType="{x:Type myNameSpace:myViewModel2}">
                                    <myNameSpace:myControl2/>
                                 </DataTemplate>
                              </ResourceDictionary>
                           </ContentControl.Resources>
                        </ContentControl>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
