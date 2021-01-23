    public bool CanShowStatusChange
    {
      get
      {  
        if (_authService.GetAccessLevel(1470) > AuthorizationLevel.None)
        {
            if (SelectedFloorplan!=null)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
      }
    }
