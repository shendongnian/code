            <ContextMenu.ItemTemplate>
                  <DataTemplate>
                      <Grid Margin="-20,0,-50,0">
                          <Grid>
                              <Grid.ColumnDefenitions>
                                   <ColumnDefenition />
                                   <ColumnDefenition />
                               </Grid.ColumnDefenitions>
                               <Image Source="{Binding Path=., Converter={StaticResource EnumImageConverter}}" />
                               <TextBlock Grid.Column="1" Text="{Binding Path=., Converter={StaticResource EnumDescriptionConverter}}"/>
                       </Grid>
                   </DataTemplate>
           </ContextMenu.ItemTemplate>
