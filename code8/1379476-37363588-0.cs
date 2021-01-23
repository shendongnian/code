    foreach (DataGridViewRow row in BedsDataGridView.Rows)
    {
         beds beds = new beds(); // Here is its place.
         beds.Bedno = row.Cells[0].Value.ToString();
         beds.FullRoomNo = row.Cells[1].Value.ToString();
         beds.RoomStatus = "Available";
         m3d.beds.AddObject(beds);
    }
