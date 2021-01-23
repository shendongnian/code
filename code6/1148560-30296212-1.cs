    <ListView ItemsSource="{Binding SimpleCollection}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="First column">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding A}"></TextBlock>
                                    <TextBlock Text="{Binding C}"></TextBlock>
                                    <TextBlock Text="{Binding E}"></TextBlock>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Second column">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding B}"></TextBlock>
                                    <TextBlock Text="{Binding D}"></TextBlock>
                                    <TextBlock Text="{Binding F}"></TextBlock>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
