    <Grid>
        <ItemsControl ItemsSource="{Binding Customers}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Border CornerRadius="5" BorderBrush="RoyalBlue" BorderThickness="1" 
                        Padding="5" Margin="5">
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding name}" Margin="5" />
                            <ItemsControl ItemsSource="{Binding Brands}">
                                <ItemsControl.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <StackPanel Orientation="Horizontal" />
                                    </ItemsPanelTemplate>
                                </ItemsControl.ItemsPanel>
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <CheckBox Content="{Binding name}" Margin="5" />
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </StackPanel>
                    </Border>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
