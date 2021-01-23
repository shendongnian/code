        List<Task<ResponseBase>> _actionsDict = new List<Task<ResponseBase>>();
        Timer _timer = new Timer(1000);
        
        public ExecutingScheduler()
        {
            _timer.Elapsed += (s, e) => {
                while (_actionsDict.Count > 0) {
                    var a = _actionsDict[0];
                    _actionsDict.RemoveAt(0);
                    
                    a.Start();
                    a.Wait();
                }
            };
            _timer.Start();
        }
    
        public Task<ResponseBase> StartStreamAsync(ClassA classA, ClassB classB)
        {
            return QueueResponse(() => StartStream(classA, classB));
        }
    
        public Task<ResponseBase> PrepareStreamAsync(ClassA classA, ClassB classB)
        {
            return QueueResponse(() => PrepareStream(classA, classB));
        }
    
        public Task<ResponseBase> QueueResponse(Func<ResponseBase> action)
        {
            var t = new Task<ResponseBase>(action);
            _actionsDict.Add(t);
            return Task.Run(() => t.Result);
        }
