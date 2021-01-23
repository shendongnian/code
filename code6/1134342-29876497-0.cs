    <Expander Name="myExpander" Background="Tan" 
          HorizontalAlignment="Left" Header="My Expander" 
          ExpandDirection="Down" IsExpanded="True" Width="Auto">
        <ItemsControl Name="items">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Text="{Binding FirstDisplayColumn}"/>
                        <TextBlock Grid.Column="1" Text="{Binding SecondDisplayColumn}"/>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Expander>
