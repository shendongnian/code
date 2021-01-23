    <Grid>
        <my:UC1 Name="UC1" />
        <my:UC2 Name="UC2" Visibility="Collapsed"/>      
    </Grid>
    private void button2_click(object sender, MouseButtonEventArgs e)
    {
        this.UC1.Visibility = System.Windows.Visibility.Collapsed;
        this.UC2.Visibility = System.Windows.Visibility.Visible;
    }
