       <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition  x:Name="TestColumn"  Width="*"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Grid Column="0" Background="Aqua"></Grid>
            <Grid Column="1" Background="Red"></Grid>
           <Button Grid.Column="2" Click="hideColumn">hideColumn</Button>
        </Grid>
     private void hideColumn(object sender, RoutedEventArgs e)
            {
                this.TestColumn.Width = new GridLength(0, GridUnitType.Pixel);
            }
