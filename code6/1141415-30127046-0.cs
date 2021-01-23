    <ItemsControl
        ItemsSource="{Binding Path=FeildSet}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <HeaderedContentControl
                    Header="{Binding Path=Key}">
                    <ItemsControl
                        ItemsSource="{Binding Path=.}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <!-- template for SomeClass here -->
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </HeaderedContentControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
