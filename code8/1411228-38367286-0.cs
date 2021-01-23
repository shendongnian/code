    <ItemsControl ItemsSource="{Binding FooBar}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>
                    <TextBox Text="{Binding FirstName}" Grid.Column="0"/>
                    <TextBox Text="{Binding LastName}" Grid.Column="1"/>
                    <TextBox Text="{Binding Age}" Grid.Column="2"/>
                    <Button Content="X" Grid.Column="3" Command="{Binding YOURDELETECOMMAND}"
                            Visibility="{Binding Deletable, Converter={StaticConverter BooleanToVisibilityConverter}}"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
