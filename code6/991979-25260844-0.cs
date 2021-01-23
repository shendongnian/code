        <Window.Resources>
        <DataTemplate x:Key="lbIssueTemplate">
            <Grid Margin="0" Width="Auto">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition />
                    <ColumnDefinition />
                    <ColumnDefinition />
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition />
                    <RowDefinition />
                </Grid.RowDefinitions>
                <ComboBox x:Name="PrintCode" Grid.Row="0" Grid.Column="2"
                          SelectedValue="{Binding DataContext.PrintCode, RelativeSource={RelativeSource Mode=Self}, Mode=TwoWay}" 
                          ItemsSource="{Binding DataContext.Choices, RelativeSource={RelativeSource AncestorType={x:Type Window}}}"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <StackPanel>
        <ListBox Background="Red" ItemTemplate="{StaticResource lbIssueTemplate}" ItemsSource="{Binding Equips}"></ListBox>
    </StackPanel>
