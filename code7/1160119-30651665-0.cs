    private void reverseGeocode_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {    
       if (e.Error == null && e.Result != null && e.Result.Count > 0)
       {
           MapAddress address = e.Result[0].Information.Address;
           MessageBox.Show(address.Country);
       }
    }
