    using Hashtable = ExitGames.Client.Photon.Hashtable;
    
    public void SetProperties () {
      Hashtable setPlacingStone = new Hashtable {{ RoomProperties.PlacingStone, true }
    
    PhotonNetwork.room.SetCustomProperties ( setPlacingStone );
    
        StartCoroutine ( "WaitOnStone" );
    }
