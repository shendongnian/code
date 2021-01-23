    <ListView ItemsSource="{Binding ShortcutItems}" >
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Icon">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="{Binding BitMapIcom}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}" />
                </GridView>
            </ListView.View>
        </ListView>
