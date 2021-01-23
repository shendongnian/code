    <ItemsControl HorizontalAlignment="Stretch">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="33*"/>
                            <ColumnDefinition Width="33*"/>
                            <ColumnDefinition Width="33*"/>
                        </Grid.ColumnDefinitions>
                        <Border Grid.Column="0" Background="{Binding IsEnabled, Converter={StaticResource BackgroundConverter}}">
                            <TextBlock Text="{Binding Text0}" />
                        </Border>
                        <Border Grid.Column="1" Background="{Binding IsEnabled, Converter={StaticResource BackgroundConverter}}">
                            <TextBlock Text="{Binding Text1}" />
                        </Border>
                        <Border Grid.Column="2" Background="{Binding IsEnabled, Converter={StaticResource BackgroundConverter}}">
                            <TextBlock Text="{Binding Text2}" />
                        </Border>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
