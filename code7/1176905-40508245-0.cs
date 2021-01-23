    <ItemsControl x:Name="ItemGroups" Grid.Column="2" Grid.Row="0"   ItemsSource="{Binding Model.ItemGroups}" ScrollViewer.VerticalScrollBarVisibility="Auto" >
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Expander Margin="4,0"   Header="{Binding}">
                            <Expander.HeaderTemplate>
                                <DataTemplate>
                                    <Grid  HorizontalAlignment="{Binding Path=HorizontalAlignment, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ContentPresenter}}, Mode=OneWayToSource}" >
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition   />
                                            <ColumnDefinition  Width="Auto"/>
                                            <ColumnDefinition  Width="64"/>
                                        </Grid.ColumnDefinitions>
                                        <TextBox Grid.Column="0"  Text="{Binding Name, Mode=TwoWay}" />
                                        <TextBlock Grid.Column="1" Text="{Binding TotalCostString}" Margin="4,0"/>
                                        <Button Grid.Column="2" Command="{Binding DataContext.RemoveItemGroup, ElementName=ItemGroups, Mode=OneWay}" CommandParameter="{Binding}" Content="Remove"/>
                                    </Grid>         
                                </DataTemplate>
                            </Expander.HeaderTemplate>
                            <Expander.Content>
                                <TextBlock Text="{Binding Summary}"></TextBlock>
                            </Expander.Content>
                        </Expander>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
