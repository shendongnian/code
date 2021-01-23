      <Page.DataContext>
            <local:ViewModel />
        </Page.DataContext>
    
        <Page.Resources>
            <CollectionViewSource 
                x:Key="cvs" 
                Source="{Binding GroupedContacts}" 
                IsSourceGrouped="True" />
        </Page.Resources>
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
    
            <ListView ItemsSource="{Binding Source={StaticResource cvs}}"
                      x:Name="targetListBox">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="100" />
                                <ColumnDefinition Width="100" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
    
                            <TextBlock Text="{Binding LastName}" />
                            <TextBlock Text="{Binding FirstName}" Grid.Column="1" />
                            <TextBlock Text="{Binding State}" Grid.Column="2" HorizontalAlignment="Right" />
                        </Grid>
                    </DataTemplate>
                </ListView.ItemTemplate>
                <ListView.GroupStyle>
                    <GroupStyle>
                        <GroupStyle.HeaderTemplate>
                            <DataTemplate>
                                <Grid Background="Gainsboro">
                                    <TextBlock FontWeight="Bold" 
                                               FontSize="14" 
                                               Margin="10,2"
                                               Text="{Binding Key}"/>
                                </Grid>
                            </DataTemplate>
                        </GroupStyle.HeaderTemplate>
                    </GroupStyle>
                </ListView.GroupStyle>
            </ListView>
    
            <StackPanel Orientation="Horizontal" Grid.Row="1">
                <Button Content="Group By Initial" Command="{Binding GroupByNameCommand}" />
                <Button Content="Group By State" Command="{Binding GroupByStateCommand}" />
            </StackPanel>
        </Grid>
