    ....
    Task.Factory.StartNew(() =>
        {
            if (message.Delay != null)
            {
                foreach (var plane in message.Planes)
                {
                    AddPins(new[] {plane});
                    Thread.Sleep(message.Delay.Value);
                }
            }
        });
    ....
    private void AddPins(IEnumerable<IPlane> planes)
    {
        DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                foreach (var plane in planes)
                {
                    var pushpin = new Pushpin
                        {
                            Style = Resources["PlaneStyle"] as Style
                        };
                    var pushpinOverlay = new MapOverlay
                        {
                            GeoCoordinate = plane.Location,
                            Content = pushpin
                        };
                    _pushpinLayer.Add(pushpinOverlay);
                }
            });
    }
 
