    List<TouchInfo> touchEvents = new List<TouchInfo>();
    public void initializeTouchDataListObject()
    {
        for (int a = 0; a < DataStructure.maxButtonsActive; a++)
        {
            touchEvents.add(new TouchInfo());
        }
    }
