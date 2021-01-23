    <DataGridComboBoxColumn SelectedValueBinding="{Binding Contractor, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
                            DisplayMemberPath="Acronym">     
        <DataGridComboBoxColumn.ElementStyle>
             <Style TargetType="{x:Type ComboBox}">
                 <Setter Property="ItemsSource" Value="{Binding Path=Contractors, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
             </Style>
         </DataGridComboBoxColumn.ElementStyle>
         <DataGridComboBoxColumn.EditingElementStyle>
             <Style TargetType="{x:Type ComboBox}">
                 <Setter Property="ItemsSource" Value="{Binding Path=Contractors, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
             </Style>
         </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
