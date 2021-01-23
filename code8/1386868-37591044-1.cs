    private void AddTripConfirm_Click(object sender, EventArgs e) 
    {　　　　　　　　　　　　　　　　　　　　　　　　　
        Trips newTrip = new Trips();
        newTrip.Name = AddTripNametxt.Text;
        newTrip.Time = AddTripTimetxt.Text;
        _allTrips.Add(newTrip); // use the member _allTrips
    }
