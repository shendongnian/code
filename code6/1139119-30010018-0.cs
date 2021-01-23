    private void OrientAvatar()
    {
        Debug.Log(ControlVector.x);
        if (ControlVector.x >= DeadZone)
        {
            Spin = -90;
        }
        if (ControlVector.x <= -DeadZone)
        {
            Spin = 90;
        }
        if (ControlVector.y > DeadZone && Ladder)
        {
            Spin = 180;
        }
        Pivot.eulerAngles = new Vector3(Pivot.rotation.x, Spin, Pivot.rotation.z);  
    }
