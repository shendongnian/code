    <ListView.View>
      <GridView>
        <GridViewColumn x:Name="TimeColumn" Header="Time" Width="80">
          <GridViewColumn.CellTemplate>
            <DataTemplate>
              <StackPanel Orientation="Horizontal">
                <Image /> <!-- YOU NEED TO POINT THIS TO YOUR IMAGE -->
                <TextBlock Text="{Binding Time}"/>
              </StackPanel>
            </DataTemplate>
          </GridViewColumn.CellTemplate>
        </GridViewColumn>
      </GridView>
    </ListView.View>
