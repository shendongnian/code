    <ListView Grid.Row="0" Grid.Column="1" x:Name="ListBoxSelectedFolder" ItemsSource="{Binding Path=SelectedFolder.PlayableElements}">
      <ListView.Resources>
        <DiscreteObjectKeyFrame x:Key="proxy" Value="{Binding RelativeSource={RelativeSource AncestorType=Window}}"/>
        <ContextMenu x:Key="ContextMenu" DataContext="{Binding Value, Source={StaticResource proxy}}">
          <MenuItem Header="Add to" ItemsSource="{Binding Playlists}">
             <MenuItem.ItemTemplate>
                 <DataTemplate>                     
                     <TextBlock Text="{Binding Name}"/>        
                 </DataTemplate>
             </MenuItem.ItemTemplate>
          </MenuItem>
          <MenuItem Header="Playable elements" ItemsSource="{Binding SelectedFolder.PlayableElements}"/>
          <MenuItem Header="Remove from All" />
        </ContextMenu>
        <Style TargetType="{x:Type ListViewItem}">
         <Setter Property="ContextMenu" Value="{StaticResource ContextMenu}"/>
        </Style>
      </ListView.Resources>
      <!-- ... -->
    </ListView>
