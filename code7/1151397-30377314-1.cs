    <...>
        <ItemsControl ItemsSource="{Binding CurrentRoom.Seats}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid
                        Columns="{Binding CurrentRoom.Columns}"
                        Rows="{Binding CurrentRoom.Rows}"
                    />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Button Command="{Binding Buy}">
                        <TextBlock Text="{Binding State}"/>
                    </Button>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </...>
