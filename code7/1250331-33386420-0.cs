    <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridComboBoxColumn Header="Category" Width="120"
                                        DisplayMemberPath="CategoryName">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.VmCategories, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.VmCategories, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>    
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
