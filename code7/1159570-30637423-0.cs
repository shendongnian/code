    gm = new GoogleMap(Obj.defaultOrigin);
    overlay = new GMapOverlay(gm, "mapIcon");
    marker = new GoogleMap.GMapMarkerImage(Obj.defaultOrigin, Image.FromFile(Obj.path + @"\resources\images\mapIcon.png"));
    overlay.Markers.Add(marker);
    gm.Overlays.Add(overlay);
    gm.MouseClick += (s, e) =>
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            GMap.NET.PointLatLng point = gm.FromLocalToLatLng(e.X, e.Y);
            marker.Position = point;
        }
    };
