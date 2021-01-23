    <Grid>
                <ListView Margin="10" Name="lvUsers" SelectedIndex="{Binding Selected}">
                    <ListView.View>
                        <GridView>
                            <GridViewColumn>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                        <CheckBox Tag="{Binding ID}"  IsChecked="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=IsSelected}"/>
                                    </DataTemplate>
                                </GridViewColumn.CellTemplate>
                            </GridViewColumn>
                            <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Name}" />
                            <GridViewColumn Header="Age" Width="50" DisplayMemberBinding="{Binding Age}" />
                            <GridViewColumn Header="Mail" Width="150" DisplayMemberBinding="{Binding Mail}" />
                        </GridView>
                    </ListView.View>
                </ListView>
            </Grid>
