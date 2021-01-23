    <Window.Resources>
        <local:BoolToImageConverter x:Key="image_converter"/>
        <local:BoolToTooltipConverter x:Key="tooltip_converter"/>
    </Window.Resources>
    [...]
    <ListView x:Name="listView" ItemsSource="{Binding List}">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="System" DisplayMemberBinding="{Binding Name}" Width="100"/>
                <GridViewColumn Header="Status">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Button ToolTip="{Binding IsActive, Converter={StaticResource tooltip_converter}}">
                                <Image Source="{Binding IsActive, Converter={StaticResource image_converter}}" Width="15"/>
                            </Button>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
