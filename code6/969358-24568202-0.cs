    <Grid xmlns:l="clr-namespace:CSharpWPF">
        <ListView l:NavigationHelper.IsEnabled="True">
            <sys:String>item 1</sys:String>
            <sys:String>item 2</sys:String>
            <sys:String>item 3</sys:String>
            <sys:String>item 4</sys:String>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Expander Header="{Binding}">
                        <Expander.Content>
                            <ListView ItemsSource="{Binding}"
                                      l:NavigationHelper.IsEnabled="True">
                                <ListView.ItemContainerStyle>
                                    <Style TargetType="ListViewItem">
                                        <Setter Property="IsSelected"
                                                Value="{Binding IsSelected}" />
                                    </Style>
                                </ListView.ItemContainerStyle>
                            </ListView>
                        </Expander.Content>
                    </Expander>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
