    <GridView>
                                        <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Name}" />
                                        <GridViewColumn Header="Age" Width="50" DisplayMemberBinding="{Binding Age}" />
                                        <GridViewColumn Header="Mail" Width="150">
                                                <GridViewColumn.CellTemplate>
                                                        <DataTemplate>
                                                                <TextBlock Text="{Binding Mail}" TextDecorations="Underline" Foreground="Blue" Cursor="Hand" />
                                                        </DataTemplate>
                                                </GridViewColumn.CellTemplate>
                                        </GridViewColumn>
                                </GridView>
