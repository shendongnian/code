    <DataGrid ... >
       <DataGrid.Resources>
           <ContextMenu x:Key="cm">
                <MenuItem Header="Edit Item" Click="EditItem_Click"/>
                <MenuItem Header="Delete Item" Click="DeleteItem_Click"/>
           </ContextMenu>
       </DataGrid.Resources>
       <DataGrid.Style>
          <Style TargetType="DataGrid">
             <Style.Triggers>
                 <DataTrigger Binding="{Binding SelectedItems.IsEmpty, 
                              RelativeSource={RelativeSource Self}}" Value="false">
                     <Setter Property="ContextMenu" Value="{StaticResource cm}"/>
                 </DataTrigger>
             </Style.Triggers>
          </Style>
       </DataGrid.Style>
       <!-- remaining code -->
    </DataGrid>
