     <ListView Margin="0,0,0,0" Name="EpisodesList">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Season" Width="Auto">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <TextBlock Text="{Binding Season}"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Episode" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <TextBlock Text="{Binding Episode}"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Assitido" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <CheckBox IsChecked="{Binding Watched}" Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked" />
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Baixar" Width="50">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <CheckBox IsChecked="{Binding Download}" Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked"/>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
