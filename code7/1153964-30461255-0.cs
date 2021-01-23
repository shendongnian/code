    private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            //use e.Source to check which element was clicked, like this:
            if (e.Source.GetType() == typeof(Border))
            {
                MessageBox.Show("The border was clicked");
            }
            //Or, you can check the name of the element, like this:
            if (((FrameworkElement)e.Source).Name == "myBorderName")
            {
                //Something useful.
            }
        }
