    public void Version(string versionNo)
    {
        versionNo = versionNo.PadRight(6);
        Group.Gs.D_480_8 = versionNo.Substring(0, 6);
    }
