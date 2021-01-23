    <ListBox x:Name="BoardList"  >
     <ListBox.ItemTemplate>
         <DataTemplate>
              <Grid>
                 <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                     <TextBox IsReadOnly="True" ScrollViewer.VerticalScrollBarVisibility="Visible" Text="{Binding text}" TextWrapping="Wrap" Foreground="DarkBlue"></TextBox>
                     <AppBarButton Visibility="{Binding visibility}" Icon="Globe" Click="OpenInBrowser"></AppBarButton>
                     <AppBarButton Icon="Copy" Click="Copy"></AppBarButton>
                     <AppBarButton Icon="Delete" Click="Delete"></AppBarButton>
                 </StackPanel>
              </Grid>
         </DataTemplate>
     </ListBox.ItemTemplate>
    </ListBox>
