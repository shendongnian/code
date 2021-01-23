    for (i = 0; i <=t.Longitudelist.Count-1 ; i++)
                {
    
                    MapIcon mapIcon1 = new MapIcon();
                    string latitudetxt;
                    string longitudetxt;
                    latitudetxt = t.Latitudelist[i].Text;
                    longt.Add(latitudetxt);
                    longitudetxt = t.Longitudelist[i].Text;
                    lati.Add(longitudetxt);
                    // mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png"));
                    mapIcon1.Location = new Geopoint(new BasicGeoposition()
                    {
                        
                       Latitude = Convert.ToDouble(longt[i]),
                       Longitude = Convert.ToDouble(lati[i])
                    });
                   // mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png"));
                    mapIcon1.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    Map.MapElements.Add(mapIcon1);
    
                    var bt = new Button();
                    buttonn.Add(bt);
                    bt.Content = "";
                    bt.Width = 30;
                    bt.Height = 50;
                    bt.Opacity = 10;
                    bt.Content = i;
                     // button.
                    this.Map.Children.Add(bt);
                    // assign geoposition
                    var position = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = Convert.ToDouble(longt[i]),
                        Longitude = Convert.ToDouble(lati[i])
                        
                    });
                    MapControl.SetLocation(buttonn[i], position);
                    var pointt=MapControl.GetLocation(bt);
                    pointt.Position.Latitude.ToString();
                    pointt.Position.Longitude.ToString();
                    //longg= position.Position.Latitude;
                    //latt = position.Position.Longitude;
                  //  button.Tag = longg;
    
                    MapControl.SetNormalizedAnchorPoint(bt, new Point(0.5, 0.5));
                    MapControl.SetIsTemplateFocusTarget(bt, true);
    
                    bt.Click += Button_Click;
    
                    await Map.TrySetViewAsync(mapIcon1.Location, 18D, 0, 0, MapAnimationKind.Bow);
                  
                }
