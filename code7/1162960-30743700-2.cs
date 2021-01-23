    <ListView HorizontalAlignment="Left" Grid.Row="1" Width="400">
        <ListView.View>
            <GridView>
                <GridViewColumn Width="140">
                    <GridViewColumn.Header>
                        <StackPanel Orientation="Horizontal">
                            <Checkbox IsChecked="{Binding YourCheckedProperty}">
                            <TextBlock>Column1</TextBlock>
                        </StackPanel>
                    <GridViewColumn.Header>
                </GridViewColumn>
                <GridViewColumn Width="140" Header="Column2" />
                <GridViewColumn Width="115" Header="Column3" />
            </GridView>
        </ListView.View>
    </ListView>
