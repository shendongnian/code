    class RouteMessageHandler : Java.Lang.Object, IRouteManagerMessageHandler
    {
        public void Process(Message p0)
        {
            var message = p0;
            Log.Info(LOG_TAG, message);
        }
    }
