    var input = new[] { "A", "B", "E" };
    // start with reservations
    var room = reservations
        // create a grouping by the room number
        .GroupBy(r => r.RoomNo)
        // filter groupings that contain all `input` elements
        .Where(g => input.All(i => g.Select(rs => rs.User).Contains(i)))
        // filter groupings to those whose reservations only include elements in `input` 
        .Where(g => g.All(r => input.Contains(r.User)))
        // select the grouping key, which is the room number. 
        .Select(g => g.Key);
