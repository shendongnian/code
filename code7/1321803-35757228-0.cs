    protected override void OnSaving() 
    {
        if (VolumeOrVolumePoints == VolumeType.Volume)
        {
            if (RealVolume % 1 != 0) // see http://stackoverflow.com/a/2751597/1077279
                 throw new Exception("The RealVolume value must be an integer when using Volume units.");
        }
    }
