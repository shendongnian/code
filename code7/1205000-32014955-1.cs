    foreach (int[] i in ValidCoordinates)
    {
         int[] coords = i;
         double apotema = Math.Sqrt(Math.Pow(20, 2) - Math.Pow(20 / 2, 2));
         double auxX = x + (coords[0] * (20 * 3 / 2));
         double auxY = y + (coords[0] * apotema + (coords[1] * apotema * 2));
         Polygon poly = Hex.HexagonalPolygon(20, auxX, auxY);
         poly.Fill = Brushes.Blue;
         Hexagon.Tile tile = new Hexagon.Casilla();
         tile.coords = coords;
         tile.hex = poly;
         ListTiles.Add(tile);
    }
    ...
    //put values into tile and then set as tag
    PolyCanvas.Tag = tile;
    ...
    private void PolyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
    {    
         var canvas = sender as System.Windows.Controls.Canvas;
         if (canvas.Name == "PolyCanvas")
         {
              var tiles = (Tile)canvas.Tag;
         }
    }
