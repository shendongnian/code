    <DataGrid ... >
       <DataGrid.Style>
          <Style TargetType="DataGrid">
             <Style.Triggers>
                 <DataTrigger Binding="{Binding SelectedItems.IsEmpty, 
                              RelativeSource={RelativeSource Self}}" Value="false">
                     <Setter Property="ContextMenu">
                        <Setter.Value>
                            <ContextMenu>
                              <MenuItem Header="Edit Item" Click="EditItem_Click"/>
                              <MenuItem Header="Delete Item" Click="DeleteItem_Click"/>
                            </ContextMenu>
                        </Setter.Value>
                     </Setter>
                 </DataTrigger>
             </Style.Triggers>
          </Style>
       </DataGrid.Style>
       <!-- remaining code -->
    </DataGrid>
