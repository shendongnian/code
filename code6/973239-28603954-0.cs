    public static class BingMapsFix
    {
        public static void UnhookAnimationDrivers(Map map)
        {
            Type type = typeof(MapCore);
    
            object zoomAndPanAnimationDriver = type.GetField("_ZoomAndPanAnimationDriver", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField).GetValue(map);
            object modeSwitchAnationDriver = type.GetField("_ModeSwitchAnationDriver", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField).GetValue(map);
    
            UnhookAnimationDriver(zoomAndPanAnimationDriver);
            UnhookAnimationDriver(modeSwitchAnationDriver);
        }
    
        private static void UnhookAnimationDriver(object animationDriver)
        {
            Type type = animationDriver.GetType();
    
            var f = type.GetField("AnimationProgressProperty", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField).GetValue(animationDriver);
    
            DependencyProperty dp = (DependencyProperty)f;
    
            var m = type.GetMethod("OnAnimationProgressChanged", BindingFlags.Instance | BindingFlags.NonPublic);
    
            EventHandler eh = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), animationDriver, m);
    
            DependencyPropertyDescriptor.FromProperty(dp, type).RemoveValueChanged(animationDriver, eh);
        }
    }
