    <TreeView  ItemsSource="{Binding Leafs}">                                
      <TreeView.Resources>                    
        <HierarchicalDataTemplate DataType="{x:Type vm:LeafViewModel}" ItemsSource="{Binding Children}">
           <ContentControl Content="{Binding }">
             <ContentControl.Style>
               <Style TargetType="{x:Type ContentControl}">
                  <Setter Property="ContentTemplate" Value="{StaticResource DefaultTemplate}"/>
               </Style>
             </ContentControl.Style>
           </ContentControl>                        
       </HierarchicalDataTemplate>
     </TreeView.Resources>            
    </TreeView>
