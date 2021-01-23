    <GridView>
        <GridViewColumn Width="150" Header="Date And Time" DisplayMemberBinding="{Binding TimeStamp}">
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <TextBlock TextWrapping="WrapWithOverflow" TextAlignment="Center" Text="{Binding}"/>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
        <GridViewColumn Width="50" Header="Status" DisplayMemberBinding="{Binding Status}">
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <TextBlock TextWrapping="WrapWithOverflow" TextAlignment="Center" Text="{Binding}"/>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
        <GridViewColumn Width="1800" Header="Message" DisplayMemberBinding="{Binding Message}">
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                    <TextBlock TextWrapping="WrapWithOverflow" Text="{Binding}"/>
                </DataTemplate>
            </GridViewColumn.CellTemplate>
        </GridViewColumn>
    </GridView>
