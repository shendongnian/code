    <ListView Grid.Row="0" Grid.Column="1" x:Name="ListBoxSelectedFolder" ItemsSource="{Binding Path=SelectedFolder.PlayableElements}">
      <ListView.Resources>
        <DiscreteObjectKeyFrame x:Key="proxy" Value="{Binding Playlists, RelativeSource={RelativeSource AncestorType=Window}}"/>
        <ContextMenu x:Key="ContextMenu">
          <MenuItem Header="Add to" ItemsSource="{Binding Value, Source={StaticResource proxy}}">
             <MenuItem.ItemTemplate>
                 <DataTemplate>
                     <TextBlock Text="{Binding Name}"/>
                 </DataTemplate>
             </MenuItem.ItemTemplate>
          </MenuItem>
          <MenuItem Header="Remove from All" />
        </ContextMenu>
        <Style TargetType="{x:Type ListViewItem}">
         <Setter Property="ContextMenu" Value="{StaticResource ContextMenu}"/>
        </Style>
      </ListView.Resources>
      <!-- ... -->
    </ListView>
