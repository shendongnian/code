    <ItemsControl ItemsSource="{Binding Nodes}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <HeaderedContentControl Header="{Binding Name}">
                    <ItemsControl ItemsSource="{Binding Modules}"
                                  Margin="10,0,0,0">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <HeaderedContentControl Header="{Binding Name}">
                                    <ItemsControl ItemsSource="{Binding Channels}"
                                                  Margin="10,0,0,0">
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <CheckBox IsChecked="{Binding State}"
                                                          Content="{Binding Name}"
                                                          Command="{Binding Command}" />
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
                                </HeaderedContentControl>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </HeaderedContentControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
