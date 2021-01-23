    bool IsException(int x, int y)
    {
        string key = x.ToString() + ";" + y.ToString();
        return _seatsExceptions.Contains(key);
    }
    bool ExistsReservation(int x, int y)
    {
        string key = x.ToString() + ";" + y.ToString();
        return _seatsReservations.Contains(key);
    }
