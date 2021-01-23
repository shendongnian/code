    <Grid>
        <DataGrid x:Name="DGOrders" Margin="30" AutoGenerateColumns="False" ItemsSource="{Binding OrdersCollection}">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding OrderId}" Header="Order ID" />
                <DataGridTemplateColumn Header="User" Width="200" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox SelectedValue="{Binding SelectedUserId}" SelectedValuePath="UserId" DisplayMemberPath="CompanyName" HorizontalContentAlignment="Stretch" ItemsSource="{Binding DataContext.UsersCollection,ElementName=DGOrders}" >
                                <ComboBox.ItemContainerStyle>
                                    <Style TargetType="{x:Type ComboBoxItem}">
                                        <Setter Property="Template">
                                            <Setter.Value>
                                                <ControlTemplate>
                                                    <Grid>
                                                        <Grid.ColumnDefinitions>
                                                            <ColumnDefinition Width="Auto"/>
                                                            <ColumnDefinition Width="*"/>
                                                            <ColumnDefinition Width="*"/>
                                                        </Grid.ColumnDefinitions>
                                                        <TextBlock Margin="5" Grid.Column="0" Text="{Binding UserId}"/>
                                                        <TextBlock Margin="5" Grid.Column="1" Text="{Binding CompanyName}"/>
                                                        <TextBlock Margin="5" Grid.Column="2" Text="{Binding UserName}"/>
                                                    </Grid>
                                                </ControlTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </ComboBox.ItemContainerStyle>
                            </ComboBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
            </DataGrid>
    </Grid>
