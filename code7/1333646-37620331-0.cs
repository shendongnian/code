    <GridView SelectionMode="None" ItemsSource="{Binding}" 
        <GridView.ItemTemplate>
            <DataTemplate x:DataType="YourType">
                <Grid  Tapped="Grid_Tapped_For_Every_Item">
                   ...                   
                </Grid>
            </DataTemplate>
        </GridView.ItemTemplate>
        ...
    </GridView>
    in code file:
    
    private void Grid_Tapped_For_Every_Item(object sender, TappedRoutedEventArgs e){
        
        var g = (Grid) sender;
        var myClass = (YourType)g.DataContext;
        //Do whatever you were going to do in the SelectionChanged event
    } 
