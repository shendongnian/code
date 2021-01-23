    <DataGridComboBoxColumn x:Name="active_idnt_deviceCmb"
                                        SelectedValuePath="value"
                                        DisplayMemberPath="display"                                         
                                        SelectedValueBinding="{Binding A}"                                        
                                        Header="input id" Width="80">
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=FirstList}" />   
                        </Style>
                       </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
                <DataGridComboBoxColumn  
                                        SelectedValuePath="value"
                                        DisplayMemberPath="display"                                        
                                        SelectedValueBinding="{Binding B}"
                                        Header="Relay Address" Width="65">
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=SecondList}" />                                  
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
