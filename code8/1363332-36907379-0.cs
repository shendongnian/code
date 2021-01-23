    <TreeView  ItemsSource="{Binding Leafs}" Name="tv">
       <TreeView.Resources>
          <HierarchicalDataTemplate DataType="{x:Type local:LeafViewModel}" 
                                          ItemsSource="{Binding Children}">
             <StackPanel Orientation="Horizontal">
                <Label VerticalAlignment="Center" FontFamily="WingDings" Content="1"/>
                   <TextBox Text="{Binding LeafName}" Tag="{Binding DataContext, 
                      RelativeSource={RelativeSource Self}}" Background="Transparent">
                      <TextBox.ContextMenu>
                         <ContextMenu DataContext="{Binding PlacementTarget.Tag, 
                                         RelativeSource={RelativeSource Self}}">
                            <MenuItem Command="{Binding EditLeafCommand}" 
                             CommandParameter="{Binding ALeaf}" Header="Edit" />
                         </ContextMenu>
                      </TextBox.ContextMenu>
                   </TextBox>
                </StackPanel>
             </HierarchicalDataTemplate>
          </TreeView.Resources>
        <TreeView.InputBindings>
        <KeyBinding Key="F2" Command="{Binding SelectedItem.EditLeafCommand, ElementName=tv}"/>
        </TreeView.InputBindings>
    </TreeView>
