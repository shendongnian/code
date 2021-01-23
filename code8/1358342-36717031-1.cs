    <Window.DataContext>
        <local:ViewModel/>
    </Window.DataContext>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <StackPanel Orientation="Horizontal">
            <ComboBox SelectedIndex="{Binding GridColumn}">
                <ComboBoxItem>Column 0</ComboBoxItem>
                <ComboBoxItem>Column 1</ComboBoxItem>
                <ComboBoxItem>Column 2</ComboBoxItem>
            </ComboBox>
            <ComboBox SelectedIndex="{Binding GridRow}">
                <ComboBoxItem>Row 0</ComboBoxItem>
                <ComboBoxItem>Row 1</ComboBoxItem>
                <ComboBoxItem>Row 2</ComboBoxItem>
            </ComboBox>
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
