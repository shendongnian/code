        <ItemsControl ItemsSource="{Binding Source}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Grid/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <VirtualizingStackPanel Orientation="Horizontal">
                        <ContentControl>
                            <ContentControl.Resources>
                                <behavior:DataContextProxy x:Key="Proxy"
                                                           DataContext="{Binding}" />
                            </ContentControl.Resources>
                            <Path x:Name="Bound" Stroke="Black">
                            ...
