                <DataGridComboBoxColumn 
                    SelectedItemBinding="{Binding phID}" DisplayMemberPath="" >
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.BooksContainerVM.PhIdList, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.BooksContainerVM.PhIdList, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
