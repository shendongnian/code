    public RoomsViewModel(IGetAvailableRoomsService getAvailableRoomsService)
    {
        //Injection
        _getAvailableRoomsService = getAvailableRoomsService;
        //Get all rooms
        AvailableRooms =
            new ObservableCollection<AvailableRoomModel>(
                GetAvailableRooms().GetAwaiter().GetResult()
            );
        // ...
    }
