    <Window.Resources>
      <local:IndexConverter      x:Key="IndexConverter"/>
      <local:SampleTimeConverter x:Key="SampleTimeConverter"/>
    </Window.Resources>
  
    <Grid>
      <ListView Name="listviewNames" ItemsSource="{Binding MyData}">
        <ListView.View>
          <GridView>
            <GridView.Columns>
            
              <GridViewColumn Header="Index" Width="100"
                DisplayMemberBinding="{Binding RelativeSource={RelativeSource FindAncestor, 
                                               AncestorType={x:Type ListViewItem}}, 
                                               Converter={StaticResource IndexConverter}}" />
            
              <GridViewColumn Header="Time" Width="200"
                DisplayMemberBinding="{Binding RelativeSource={RelativeSource FindAncestor, 
                                               AncestorType={x:Type ListViewItem}}, 
                                               Converter={StaticResource SampleTimeConverter}}" />
            
              <GridViewColumn Header="Value" Width="auto" >
                <GridViewColumn.CellTemplate>
                  <DataTemplate>
                    <TextBox Text="{Binding Mode=OneWay}" Width="200" BorderThickness="0"/>
                  </DataTemplate>
                </GridViewColumn.CellTemplate>
              </GridViewColumn>
            
            </GridView.Columns>
          </GridView>
        </ListView.View>
      </ListView>
    </Grid>
