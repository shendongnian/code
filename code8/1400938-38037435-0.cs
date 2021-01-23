    <Grid>
        <ListView ItemsSource="{Binding Emp}">
            <ListView.ItemTemplate>
                <DataTemplate DataType="{x:Type vm:Employee }">
                    <Expander Header="{Binding Name}">
                        <ListView ItemsSource="{Binding SubEmployee}">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <TextBlock Foreground="Black" Text  ="{Binding Name}"/>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
                    </Expander>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
