    <Label Content="Dynamic Menu">
            <Label.ContextMenu>                
                <cnt:CustomContextMenu x:Name="contextMenu" ItemsSource="{Binding MenuItemsCollection}">                    
                    <ContextMenu.Resources>
                        <ResourceDictionary>                            
                            <DataTemplate DataType="{x:Type model:ExecuteMenuItem}">
                                <MenuItem Header="{Binding DisplayText}"></MenuItem>
                            </DataTemplate>
                            <DataTemplate DataType="{x:Type model:ModifyMenuItem}">
                                <MenuItem Header="{Binding DisplayText}"></MenuItem>
                            </DataTemplate>                            
                        </ResourceDictionary>
                    </ContextMenu.Resources>
                </model:CustomContextMenu>                            
            </Label.ContextMenu>
        </Label> 
