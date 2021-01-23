            <DataGrid ItemsSource="{Binding Strings}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="String" Width="SizeToCells" IsReadOnly="True">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate DataType="{x:Type soDataGridHeplAttempt:ClicableItemsModel}">
                            <ListBox HorizontalAlignment="Stretch" VerticalAlignment="Stretch" ItemsSource="{Binding ClickableItems}">
                                <ListBox.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <StackPanel Orientation="Horizontal"></StackPanel>
                                    </ItemsPanelTemplate>
                                </ListBox.ItemsPanel>
                                <ListBox.ItemContainerStyle>
                                    <Style TargetType="ListBoxItem">
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <Button  Width="70" Content="{Binding }" Style="{StaticResource ButtonInCellStyle}" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" 
                                                             Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type Window}}, Path=DataContext.Command}" 
                                                             CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=Content}"/>
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </ListBox.ItemContainerStyle>
                            </ListBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
