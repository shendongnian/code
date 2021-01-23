     <ItemsControl Name="icTodoList">
                            <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                            <Grid Margin="0,0,0,5">
                                                    <Grid.ColumnDefinitions>
                                                            <ColumnDefinition Width="*" />
                                                            <ColumnDefinition Width="100" />
                                                    </Grid.ColumnDefinitions>
                                                    <TextBlock Text="{Binding Title}" />
                                                    <ProgressBar Grid.Column="1" Minimum="0" Maximum="100" Value="{Binding Completion}" />
                                            </Grid>
                                    </DataTemplate>
                            </ItemsControl.ItemTemplate>
                    </ItemsControl>
    
