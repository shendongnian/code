        <ComboBox x:Name="cboCustHeader" Grid.IsSharedSizeScope="True">
            <ComboBox.ItemsSource>
                <CompositeCollection>
                    <ComboBoxItem IsEnabled="False">
                        <Border Style="{StaticResource ComboHeaderBorder}">
                            <Grid Style="{StaticResource ComboHeaderStyle}">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition SharedSizeGroup="A"/>
                                    <ColumnDefinition Width="7"/>
                                    <ColumnDefinition SharedSizeGroup="B"/>
                                </Grid.ColumnDefinitions>
                                <Grid.Children>
                                    <TextBlock Grid.Column="0" Text="ID"/>
                                    <TextBlock Grid.Column="2" Text="Name"/>
                                </Grid.Children>
                            </Grid>
                        </Border>
                    </ComboBoxItem>
                    <CollectionContainer Collection="{Binding Path=DpCustomerListOC, Source={StaticResource ReserveVM}}"/>
                </CompositeCollection>
            </ComboBox.ItemsSource>
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="A"/>
                            <ColumnDefinition Width="7"/>
                            <ColumnDefinition SharedSizeGroup="B"/>
                        </Grid.ColumnDefinitions>
                        <Grid.Children>
                            <TextBlock Grid.Column="0" Text="{Binding Path=CustomerId, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
                            <TextBlock Grid.Column="2" Text="{Binding Path=CustomerName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
                        </Grid.Children>
                    </Grid>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
