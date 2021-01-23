    void gvVehicle_RowStyle(object sender, RowStyleEventArgs e) {
        Vehicle v = gvVehicle.GetRow(e.RowHandle) as Vehicle;
        if(v != null){
            if(highlightEvenRowCondition) {
                if(v.VehicleData.VehicleID % 2 == 0)
                    e.Appearance.BackColor = Color.Red;
            }
            else {
                if(v.VehicleData.VehicleID % 2 != 0)
                    e.Appearance.BackColor = Color.Red;
            }
            e.HighPriority = true;
        }
    }
    bool highlightEvenRowCondition;
    void buttonChangeHighlightCondition_Click(object sender, EventArgs e) {
        highlightEvenRowCondition = !highlightEvenRowCondition;
        gvVehicle.RefreshData();
    }
