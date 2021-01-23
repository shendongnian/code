    <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Grid Margin="15,10,0,10" Height="80" Width="auto" Tag="{Binding .}">
                            <toolkit:ContextMenuService.ContextMenu>
                                <toolkit:ContextMenu IsZoomEnabled="False Opened="ContextMenu_Opened">
                                    <toolkit:MenuItem Header="delete" Tag="{Binding .}" Click="Delete_MenuItem_Click" />
                                </toolkit:ContextMenu>
                            </toolkit:ContextMenuService.ContextMenu>
