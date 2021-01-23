     <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListView Grid.ColumnSpan="2" ItemsSource="{Binding ListViewCollection}" SelectedItem="{Binding SelectedListViewItem,Mode=TwoWay}" SelectionMode="Single">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Name" Width="150" DisplayMemberBinding="{Binding Name}"/>
                    <GridViewColumn Header="Name" Width="150" DisplayMemberBinding="{Binding Val}"/>
                </GridView>
            </ListView.View>
        </ListView>
        <TextBlock Grid.Column="0" Grid.Row="1" Text="Selected Item"/>
        <TextBox Grid.Column="1" Grid.Row="1" Text="{Binding SelectedListViewItem.Val,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
    </Grid>
