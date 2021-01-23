    DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    TimeSpan _timestep = TimeSpan.FromMinutes(3);
    
    var delta = DateTime.UtcNow - _unixEpoch;
    var currentTimeStep = (ulong)(delta.Ticks / _timestep.Ticks);
