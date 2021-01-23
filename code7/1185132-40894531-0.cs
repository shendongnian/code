    <DataGrid.Columns>
      <DataGridTextColumn Binding="{Binding FeatureName}" />
      <DataGridCheckBoxColumn  Binding="{Binding FeatureExists}" />
      <DataGridComboBoxColumn DisplayMemberPath="MachineID" SelectedItemBinding="{Binding SelectedMchn}">
         <DataGridComboBoxColumn.ElementStyle>
            <Style>
              <Setter Property="ComboBox.ItemsSource" Value="{Binding Path=FeatureMachines}" />
            </Style>
         </DataGridComboBoxColumn.ElementStyle>
         <DataGridComboBoxColumn.EditingElementStyle>
            <Style>
               <Setter Property="ComboBox.ItemsSource" Value="{Binding Path=FeatureMachines}" />
            </Style>
          </DataGridComboBoxColumn.EditingElementStyle>
       </DataGridComboBoxColumn>                                
