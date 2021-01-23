    <ItemsControl ItemsSource="{Binding SomeItems}"
       Grid.IsSharedSizeScope="True">
       <ItemsControl.ItemTemplate>
         <Grid>
           <Grid.ColumnDefinitions>
             <ColumnDefinition SharedSizeGroup="ColA" Width=".5*" />
           </Grid.ColumnDefinitions>
         </Grid>
       </ItemsControl.ItemTemplate>
    </ItemsControl>
