    <Page.Resources>
        <DataTemplate x:Key="DetailContent">
            <WebView Source="{Binding DetailUri}" />
        </DataTemplate>
        <DataTemplate x:Key="ListBoxContent">
            <TextBlock Text="{Binding Title}" />
        </DataTemplate>
    </Page.Resources>
    ...
    <SplitView.Content>
        <Grid>
            <ContentPresenter Content="{x:Bind listBox.SelectedItem, Mode=OneWay}"
                              ContentTemplate="{StaticResource DetailContent}" Visibility="{x:Bind VM.IsVisible, Mode=OneWay}" />
            <ListBox x:Name="listBox" ItemsSource="{x:Bind VM.RssItems}"
                     ItemTemplate="{StaticResource ListBoxContent}" SelectionChanged="{x:Bind VM.listBox_SelectionChanged}" />
            <Button Content="Close and Show ListBox" VerticalAlignment="Bottom" Visibility="{x:Bind VM.IsVisible, Mode=OneWay}"
                    Click="{x:Bind VM.IsVisible_Clicked}" />
        </Grid>
    </SplitView.Content>
