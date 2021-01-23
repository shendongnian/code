    var markerSym = new Esri.ArcGISRuntime.Symbology.SimpleMarkerSymbol
    {
        Style = Esri.ArcGISRuntime.Symbology.SimpleMarkerStyle.Diamond,
        Color = Colors.Green,
        Size = 18
    };
    
    var pointGraphic = new Esri.ArcGISRuntime.Layers.Graphic(point, markerSym);
    
    graphicsLayer.Graphics.Add(pointGraphic);
