    <Grid >
            <Grid.Resources>
                <CollectionViewSource Source="{Binding DataObjects}" x:Key="CollectionViewSource" >
                    <CollectionViewSource.GroupDescriptions>
                        <PropertyGroupDescription PropertyName="DatabaseId"/>
                    </CollectionViewSource.GroupDescriptions>
                </CollectionViewSource>
            </Grid.Resources>
            <ListView ItemsSource="{Binding Source={StaticResource CollectionViewSource}}">
                <ListView.GroupStyle>
                    <GroupStyle>
                        <GroupStyle.ContainerStyle>
                            <Style TargetType="{x:Type GroupItem}">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate>
                                            <Expander IsExpanded="True">
                                                <Expander.Header>
                                                    <StackPanel Orientation="Horizontal">
                                                        <TextBlock Text="{Binding Name}" FontWeight="Bold" Foreground="Gray" FontSize="22" VerticalAlignment="Bottom" />
                                                        <TextBlock Text="{Binding ItemCount}" FontSize="22" Foreground="Green" FontWeight="Bold" FontStyle="Italic" Margin="10,0,0,0" VerticalAlignment="Bottom" />
                                                        <TextBlock Text=" item(s)" FontSize="22" Foreground="Silver" FontStyle="Italic" VerticalAlignment="Bottom" />
                                                    </StackPanel>
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
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding FieldId}"/>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
            <!--<simpleImageViewer:ImageViewer ImageFolder="{Binding Folder}"  x:Name="ImageViewer">
                
            </simpleImageViewer:ImageViewer>-->
        </Grid>
