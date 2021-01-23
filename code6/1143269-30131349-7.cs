    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <TreeView Grid.Row="0" Grid.Column="0" 
                  ItemsSource="{Binding Items}">
            <blend:Interaction.Behaviors>
                <view:BindableSelectedItemBehavior SelectedItem="{Binding SelectedItem, Mode=TwoWay}" />
            </blend:Interaction.Behaviors>
            <TreeView.Resources>
                <DataTemplate x:Key="tabItemTemplateLeaf">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}"/>
                    </StackPanel>
                </DataTemplate>
                <HierarchicalDataTemplate x:Key="tabItemTemplate" 
                                          ItemTemplate="{StaticResource tabItemTemplateLeaf}" ItemsSource="{Binding Children}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}"/>
                    </StackPanel>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
            <TreeView.ItemTemplate>
                <StaticResource ResourceKey="tabItemTemplate"/>
            </TreeView.ItemTemplate>            
        </TreeView>
        <TabControl Grid.Row="0" Grid.Column="1">
            <TabItem DataContext="{Binding Items[0]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}">
                <TabControl>
                    <TabItem  DataContext="{Binding Children[0]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                    <TabItem  DataContext="{Binding Children[1]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                </TabControl>
            </TabItem>
            <TabItem DataContext="{Binding Items[1]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}">
                <TabControl>
                    <TabItem  DataContext="{Binding Children[0]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                    <TabItem  DataContext="{Binding Children[1]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                </TabControl>
            </TabItem>
            <TabItem DataContext="{Binding Items[2]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}">
                <TabControl>
                    <TabItem  DataContext="{Binding Children[0]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                    <TabItem  DataContext="{Binding Children[1]}" Header="{Binding Name}" IsSelected="{Binding IsSelected}"/>
                </TabControl>
            </TabItem>
        </TabControl>
    </Grid>
