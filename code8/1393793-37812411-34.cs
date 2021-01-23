     class MobileIntegration : ChannelIntegration
        {
           public MobileIntegration()
           {
                Register<ITapGestureTrack>(new TapGestureTrack());
           }
        }
    
        class DesktopIntegration : ChannelIntegration
        {
           public DesktopIntegration()
           {
                Register<IClickTrack>(new ClickTracker());
        		Register<ILargeImagesProvider>(new LargeImagesProvider());
           }
        }
