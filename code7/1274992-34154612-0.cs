    <Grid>
        <Button Name="Button1" Content="1" Click="Button1_OnClick"/>
        <Button Name="nr1"  Visibility="Hidden" Click="Nr1_OnClick">
            <Button.Template>
                <ControlTemplate>
                    <Image  Source="YourImage" Stretch="Fill" />
                </ControlTemplate>
            </Button.Template>
        </Button>
    </Grid>
    private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            if (nr1.Visibility == Visibility.Visible)
            {
                nr1.Visibility = Visibility.Hidden;
                Button1.Visibility = Visibility.Visible;
            }
            else
            {
                nr1.Visibility = Visibility.Visible;
                Button1.Visibility = Visibility.Hidden;
            }
        }
        private void Nr1_OnClick(object sender, RoutedEventArgs e)
        {
            if (Button1.Visibility == Visibility.Visible)
            {
                Button1.Visibility = Visibility.Hidden;
                nr1.Visibility = Visibility.Visible;
            }
            else
            {
                nr1.Visibility = Visibility.Hidden;
                Button1.Visibility = Visibility.Visible;
            }
        }
