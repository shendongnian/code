      <ListView  Tag="{Binding Path=DataContext,ElementName=theViewName}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <oxy:Plot Tag="{Binding Path=Tag,RelativeSource={RelativeSource AncestorType=ListView}">
                        <oxy:Plot.ContextMenu>
                            <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Command="{Binding SavePNG}"/>
                            </ContextMenu>
                        </oxy:Plot.ContextMenu>
                    </oxy:Plot>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
