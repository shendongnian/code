    var status = geoCoordinateService.StatusObservable.Replay(1);
    var position = geoCoordinateService.PositionObservable.Replay(1);
    
    var statusConnection = status.Connect();
    var positionConnection = position.Connect();
    
    geoCoordinateWatcher.Start();
    
    status.ObserveOnDispatcher().Subscribe(this.OnStatusChanged);
    position.ObserveOnDispatcher().Subscribe(this.OnPositionChanged);
