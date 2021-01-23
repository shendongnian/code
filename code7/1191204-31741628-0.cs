    void map_Click(object sender, EventArgs e)
    {
         Console.WriteLine("Marker hit? " + ((GMapControl)sender).IsMouseOverMarker);
         Console.WriteLine("Polygon hit? " + ((GMapControl)sender).IsMouseOverPolygon);
         Console.WriteLine("Route hit? " + ((GMapControl)sender).IsMouseOverRoute);
    }
