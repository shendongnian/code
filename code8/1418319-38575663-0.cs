    <ListView ItemsSource="{Binding Source={StaticResource GroupedItems}}" Name="Playing">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Country" Width="150" DisplayMemberBinding="{Binding Source={x:Static sys:String.Empty}}" />
                <GridViewColumn Header="Leagues">
                    <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ItemsControl Margin="25 0 0 0" ItemsSource="{Binding Leagues}">
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <Expander IsExpanded="{Binding IsExpanded, Mode=TwoWay}" Margin="5" >
                                                    <Expander.Header>
                                                        <TextBlock FontSize="18" Padding="5" Text="{Binding Name}"/>
                                                    </Expander.Header>
                                                    <ItemsControl ItemsSource="{Binding Matches}">
                                                        <ItemsControl.ItemTemplate>
                                                            <DataTemplate>
                                                                <TextBlock FontSize="18" Padding="5" Text="{Binding Source={x:Static sys:String.Empty}}"/>
                                                            </DataTemplate>
                                                        </ItemsControl.ItemTemplate>
                                                    </ItemsControl>
                                                </Expander>
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header="Match">
                    <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ItemsControl Margin="25 0 0 0" ItemsSource="{Binding Leagues}">
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <Expander Style="{StaticResource MatchExpanderStyle}" IsExpanded="{Binding IsExpanded, Mode=TwoWay}" Margin="5">                                                
                                                    <Expander.Header>
                                                        <TextBlock Visibility="Hidden" FontSize="18" Padding="5" Text="{Binding Name}"/>
                                                    </Expander.Header>
                                                    <ItemsControl ItemsSource="{Binding Matches}">
                                                        <ItemsControl.ItemTemplate>
                                                            <DataTemplate>
                                                                <TextBlock FontSize="18" Padding="5" Text="{Binding Name}"/>
                                                            </DataTemplate>
                                                        </ItemsControl.ItemTemplate>
                                                    </ItemsControl>
                                                </Expander>
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
                                </DataTemplate>
                                
                            </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
        <ListView.GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Expander IsExpanded="True">
                                        <Expander.Header>
                                            <TextBlock Text="{Binding Name}" Foreground="Red" FontSize="22" VerticalAlignment="Bottom" />
                                        </Expander.Header>
                                                    <ItemsPresenter />
                                            </Expander>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GroupStyle.ContainerStyle>
            </GroupStyle>
        </ListView.GroupStyle>
    </ListView>
