    <Viewbox Stretch="Fill">
        <ItemsControl ItemsSource="{Binding HahaList}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition/>
                        </Grid.RowDefinitions>
                        <Label Content="{Binding Name}"/>
                        <ItemsControl Grid.Row="1"
                              ItemsSource="{Binding ItemList}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <UniformGrid Columns="5"/>
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="{Binding Name}" MinWidth="75"/>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
    </Viewbox>
