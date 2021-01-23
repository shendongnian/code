    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="chapterTemplate">
                <Expander Header="{Binding name}" IsExpanded="{Binding IsExpanded}">
                    <StackPanel>
                        <ItemsControl Margin="25,0,0,0"
                                      ItemsSource="{Binding pages}">
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="{Binding Path=label}">
                                    </Button>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                        <ListBox ItemsSource="{Binding chapters}"
                                 BorderBrush="{x:Null}"
                                 Margin="20,0,0,0" />
                    </StackPanel>
                </Expander>
            </DataTemplate>
            <DataTemplate DataType="{x:Type l:BookChapter}">
                <ContentControl Content="{Binding}"
                                ContentTemplate="{StaticResource chapterTemplate}" />
            </DataTemplate>
            <DataTemplate DataType="{x:Type l:SubChapter}">
                <ContentControl Content="{Binding}"
                                ContentTemplate="{StaticResource chapterTemplate}" />
            </DataTemplate>
            <DataTemplate DataType="{x:Type l:BookPage}">
                <Button Content="{Binding Path=label}" />
            </DataTemplate>
        </Grid.Resources>
        <ListBox ItemsSource="{Binding}"
                 Name="TOCView" />
    </Grid>
