    <Grid>
      <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
      </Grid.RowDefinitions>
      <ItemsControl Grid.Row="0" ItemsSource="{Binding Inventory}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <Grid Width="300">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="200"/>
                            <ColumnDefinition/>
                            <ColumnDefinition Width="30"/>
                        </Grid.ColumnDefinitions>
                        <Button Content="{Binding Name}"                        
                                MouseDoubleClick="CallEdit"/>
                    </Grid>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel MaxHeight="{Binding ElementName=window, Path=Height}"
                           Orientation="Vertical"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>                                        
        </ItemsControl>
        <StackPanel Grid.Row="1" >
            <Button Content="Add"/>
        </StackPanel>
    </Grid>
