    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        string BackGroundImgName = "myimage";
        Device.OnPlatform(iOS: () =>
        {
            if (width >= 414)
                // iPhone 6 Plus
                this.BackgroundImage = BackGroundImgName + "-736h@3x.png";
            else if (width >= 375)
                // iPhone 6
                this.BackgroundImage = BackGroundImgName + "-667h@2x.png";
            else if (width >= 320 && height >= 500)
                // iPhone 5
                this.BackgroundImage = BackGroundImgName + "-568h@2x.png";
            else if (width >= 320)
                // iPhone 4
                this.BackgroundImage = BackGroundImgName + "@2x.png";
            else
                this.BackgroundImage = BackGroundImgName + ".png";
        },
        Android: () => { this.BackgroundImage = BackGroundImgName + ".png"; }
        );
    }
