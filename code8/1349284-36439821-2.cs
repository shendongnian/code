    private void Rooms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Rooms.SelectedItem.Text != "Select a floor")
        {
             AddToDataGridView(Database.GetRoomsByFloor(int.TryParse(Rooms.SelectedItem.Value)));
        }
    }
