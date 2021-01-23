    xmlns:toolkit="clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone.Controls.Toolkit"
    <toolkit:ListView Name="listView">
        <toolkit:ListView.ItemTemplate>
           <DataTemplate>
               <Grid>
                   <Grid.ColumnDefinitions>
                       <ColumnDefinition Width="100" />
                       <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>                       
                    <TextBlock  Text="{Binding TotalQuantity}" />
                    <TextBlock Grid.Column="1" Text="{Binding Name}" />
               </Grid>
           </DataTemplate>
       </toolkit:ListView.ItemTemplate>
    </toolkit:ListView>
