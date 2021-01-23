    <DataGrid ItemsSource="{Binding Path=TarifarioSel.TarifariosDet}" 
                  IsReadOnly="False" AutoGenerateColumns="False">
            <DataGrid.Columns>                                
                <DataGridComboBoxColumn Width="200" Header="Tipo Carga" 
                    SelectedValueBinding="{Binding Path=ID_TipoCarga}"  DisplayMemberPath="Descripcion" SelectedValuePath="ID">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.TiposCarga}"/>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.TiposCarga}"/>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
