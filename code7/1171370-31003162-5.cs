        <ListView Margin="120,30,0,120" ItemsSource="{Binding MainViewModel}"
          Grid.Row="1">
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Data, Mode=TwoWay}" Width="100" Header="Column 1" />
                    <GridViewColumn DisplayMemberBinding="{Binding Year, Mode=TwoWay}" Width="100" Header="Column 2" />
                    <GridViewColumn DisplayMemberBinding="{Binding Month, Mode=TwoWay}" Width="100" Header="Column 3" />
                    <GridViewColumn DisplayMemberBinding="{Binding Weekday, Mode=TwoWay}" Width="100" Header="Column 4" />
                </GridView>
            </ListView.View>
        </ListView>
