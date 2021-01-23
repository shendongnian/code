    <ListView Width="Auto" ItemsSource="{Binding Path=PayFeeDetails}">
            <ListView.View>
                <GridView>
                <GridViewColumn Header="Description" Width="110" >
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="80"/>
                                    <ColumnDefinition Width="auto"/>
                                </Grid.ColumnDefinitions>
                                <TextBlock Grid.Column="0" Text="{Binding Path=Description}"/>
                                <CheckBox Grid.Column="1" Width="30" Name="CommentCheckBox" IsChecked="{Binding CanEdit, Mode=TwoWay}"/>
                            </Grid>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn >
                    <GridViewColumnHeader Tag="GameName" Content="Game Name" />
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Grid>
                            <TextBox Text="{Binding Path=Balance}" Visibility="{Binding CanEdit, Converter={StaticResource BoolToVisibilityConverter}}"/>
                                    <TextBlock Text="{Binding Path=Balance}" Visibility="{Binding CanEdit, Converter={StaticResource InvertedBoolToVisibilityConverter}}"/>
                        </Grid>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
                </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
