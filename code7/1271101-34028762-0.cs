    <ListView Margin="10" Name="lvUsers" ItemsSource="{Binding Users}">
         <ListView.View>
            <GridView>
               <GridViewColumn Header="Name">
                  <GridViewColumn.CellTemplate>
                     <DataTemplate>
                        <Grid>
                           <Image Source="{Binding UserIcon}"/>
                           <TextBlock Text="{Binding Name}" />
                        </Grid>
                     </DataTemplate>
                  </GridViewColumn.CellTemplate>
               </GridViewColumn>
               <GridViewColumn Header="Status">
                  <GridViewColumn.CellTemplate>
                     <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                           <Image Source="{StaticResource PrivateChatImage}" Visibility="{Binding IsPrivateChat, Converter={StaticResource BooleanToVisibilityConverter}}"/>
                           <Image Source="{StaticResource PrivateMessImage}" Visibility="{Binding IsPrivateMess, Converter={StaticResource BooleanToVisibilityConverter}}"/>
                           <Image Source="{Binding StatusIcon}"/>
                        </StackPanel>
                     </DataTemplate>
                  </GridViewColumn.CellTemplate>
               </GridViewColumn>
            </GridView>
         </ListView.View>
      </ListView>
