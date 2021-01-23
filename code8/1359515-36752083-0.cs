    public bool Execute(Reservation reservation)
        {
            //Add correct rooms to reservation;
            List<Room> roomsEntities = new List<Room>();
            foreach (var room in reservation.Room)
            {
                var roomsFound = _db.Rooms.Where(r => r.ID == room.ID).ToList();
                foreach (var ro in roomsFound)
                {
                    roomsEntities.Add(ro);
                }
            }
            //Add correct rooms to entity.
            reservation.Room = roomsEntities;
            try
            {
                _db.CreateReservation(reservation);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
