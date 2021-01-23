                  var room= (from g in m3d.rooms
                          where g.RoomNo == RoomNo
                          select g).FirstOrDefault(); //Take an objecto room to modify 
        room.FK_Stations = StationID;
       foreach (DataGridViewRow row in BedsDataGridView.Rows)
       {
          int Bedno = row.Cells[0].Value.ToString();
          var bedsChanged= (from g in m3d.beds
                          where g.bedno== Bedno
                          select g).FirstOrDefault(); 
          bedsChanged.FullRoomNo = row.Cells[1].Value.ToString();
          bedsChanged.RoomStatus = "Available";
          
        }
         m3d.SaveChanges();
