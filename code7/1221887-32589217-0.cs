    <ListView ItemsSource="{Binding ListViewItems}" x:Name="listViewMain">
        <ListView.ItemTemplate>
            <DataTemplate>
                <WrapPanel>
                    <Label Content="Test">
                        <Label.ContextMenu>
                            <ContextMenu ItemsSource="{Binding DataContext.MenuItems, Source={x:Reference listViewMain}}">
                            </ContextMenu>
                        </Label.ContextMenu>
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="PreviewMouseUp">
                                <i:InvokeCommandAction Command="{Binding DataContext.LabelMouseUpCommand, Source={x:Reference listViewMain}}" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                    </Label>
                </WrapPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
