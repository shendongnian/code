    <ListView Grid.Row="0" Grid.Column="1" x:Name="ListBoxSelectedFolder" ItemsSource="{Binding Path=SelectedFolder.PlayableElements}">
              <ListView.Resources>
                <ContextMenu x:Key="ContextMenu">
                  <MenuItem Header="Add to" ItemsSource="{Binding Path=Playlists}">
                     <MenuItem.ItemTemplate>
                        <DataTemplate>
                            <MenuItem Header="{Binding Path=Name}" />
                        </DataTemplate>
                     </MenuItem.ItemTemplate>
                    <MenuItem Header="{Binding Name}"/>
                  </MenuItem>
                  <MenuItem Header="Remove from All" />
                </ContextMenu>
              <Style TargetType="{x:Type ListViewItem}">
                 <Setter Property="ContextMenu" Value="{StaticResource ContextMenu}"/>
            </Style>
              </ListView.Resources>
              <ListView.View>
                <GridView>
                    <GridViewColumn Header="Type" DisplayMemberBinding="{Binding Extension}" />
                    <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}" />
                </GridView>
            </ListView.View>
        </ListView>
