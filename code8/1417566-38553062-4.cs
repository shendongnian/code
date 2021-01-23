    <CollectionViewSource x:Key="GroupedItems" Source="{Binding Countries}">
         <CollectionViewSource.GroupDescriptions>
             <PropertyGroupDescription PropertyName="Name"/>
         </CollectionViewSource.GroupDescriptions>
    </CollectionViewSource>
    ...
    <ListView ItemsSource="{Binding Source={StaticResource GroupedItems}}" Name="Playing">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Country" Width="150" DisplayMemberBinding="{Binding Source={x:Static sys:String.Empty}}" />
                <GridViewColumn Header="Leagues">                        
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <ItemsControl ItemsSource="{Binding Leagues}" Margin="25 0 0 0">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Grid HorizontalAlignment="Stretch" Background="#FFBCDAEC">
                                            <TextBlock FontSize="18" Padding="5" Text="{Binding Name}"/>
                                        </Grid>
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
