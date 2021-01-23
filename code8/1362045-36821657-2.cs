    public async Task<IEnumerable<AvailableRoomModel>> GetAvailableRooms()
    {
        try
        {
            return await _getAvailableRoomsService.getRooms();
        }
        catch (Exception e)
        {
            //TODO   
        }
    }
