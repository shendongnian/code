    <Grid>
        <ItemsControl ItemsSource="{Binding _schedules}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Vertical" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding TaskDT}" Margin="3" />
                        <ItemsControl ItemsSource="{Binding Tasks}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <StackPanel Orientation="Vertical" />
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Horizontal">
                                        <TextBlock Text="{Binding Name}" Margin="3" />
                                        <TextBlock Text="{Binding DueDt, StringFormat={}Due: {0}}" Margin="3" />
                                        <CheckBox IsChecked="{Binding Completed}" Content="Status:" Margin="3" />
                                    </StackPanel>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
