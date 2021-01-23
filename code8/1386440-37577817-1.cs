     private void CountryMouseEnter(object sender, MouseEventArgs e)
     {
         var path = sender as Path;
         if (path != null)
         {
             path.Fill = new SolidColorBrush(Colors.Aqua);
         }
     }
     private void Country_MouseLeave(object sender, MouseEventArgs e)
     {
         var path = sender as Path;
         if (path != null)
         {
             path.Fill = new SolidColorBrush(Colors.Black);
         }
     }
