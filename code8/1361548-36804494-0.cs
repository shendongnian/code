    <ListView Name="Users">
      <ListView.View>
        <GridView>            
            <GridViewColumn Header="Name" Width="385">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock TextWrapping="Wrap" Text="{Binding Name}" />
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
            <GridViewColumn Header="Age" Width="385">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock TextWrapping="Wrap" Text="{Binding Age}" />
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
      </ListView.View>
    </ListView>
