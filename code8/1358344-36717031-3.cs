    <Window.DataContext>
        <local:ViewModel/>
    </Window.DataContext>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <StackPanel Orientation="Horizontal">
            <TextBox Width="50"
                     Text="{Binding GridColumn, UpdateSourceTrigger=PropertyChanged}"/>
            <TextBox Width="50"
                     Text="{Binding GridRow, UpdateSourceTrigger=PropertyChanged}"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition/>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Image Source="C:\Users\Public\Pictures\Sample Pictures\Koala.jpg"
                   Grid.Column="{Binding GridColumn}" Grid.Row="{Binding GridRow}"/>
        </Grid>
    </Grid>
