    public void CalculateDistance()
            {
                Location pinLocation = new Location();
    
                foreach(Pushpin pin in bmMapdestination.Children)
                {
                    pinLocation = pin.Location;
                }
    
                txtEditPickUpEditLocation.Text = pinLocation.Latitude.ToString()+","+pinLocation.Longitude.ToString();
                
            }
