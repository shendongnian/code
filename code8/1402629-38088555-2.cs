    <Grid>
        <my:UC2 Name="UC2" Visibility="Collapsed" />
        <my:UC1 Tag="{Binding ElementName=UC2}" />
    </Grid>
    private void button2_click(object sender, MouseButtonEventArgs e)
    {
        this.Visibility = System.Windows.Visibility.Collapsed;
        var uc2 = this.Tag as UC2;
        if (uc2 != null)
            uc2.Visibility = System.Windows.Visibility.Visible;
    }
