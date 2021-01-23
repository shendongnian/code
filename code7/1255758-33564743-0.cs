        public void AddIcon()
        {
            for (int i = 0; i < pushPin.Items().Count; i++)
            {
                MapIcon myIcon = new MapIcon();
                myIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                myIcon.Title = "Apartment here";
                MyMap.MapElements.Add(myIcon);
                myIcon.Location = pushPin.MyGeopoint(i);
            }
        }
