    <ListView Margin="10" Name="listView">
       <ListView.View>
           <GridView>
               <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Name}" />
               <GridViewColumn Header="Age" Width="50" DisplayMemberBinding="{Binding Age}" />
               <GridViewColumn Header="Mail" Width="150" DisplayMemberBinding="{Binding Mail}" />
               <GridViewColumn Header="Images">
                  <GridViewColumn.CellTemplate>
                    <DataTemplate>
                       <ComboBox ItemsSource="{Binding Images}" DisplayMemberPath="Name"/>
                    </DataTemplate>
                  </GridViewColumn.CellTemplate>
              </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
