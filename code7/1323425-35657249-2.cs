    <ListView ItemsSource="{Binding TheCollection}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid Height="Auto" Margin="0,0,0,10">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBox Grid.Column="0" Text="{Binding Version, Mode=OneWay}" />
                    <TextBox Grid.Column="1" Text="{Binding Name, Mode=OneWay}" />
                    <Button Grid.Column="2" Command="{Binding VerifyCommand}" Content="Verify"/>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
