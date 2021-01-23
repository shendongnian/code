    class ExecutingScheduler<ClassA, ClassB, ResponseBase> where ResponseBase : new()
    {
        List<Func<ResponseBase>> _actionsDict;
        int _index;
        
        public ExecutingScheduler()
        {
            _actionsDict = new List<Func<ResponseBase>>();
            _index = 0;
        }
        public Task<ResponseBase> StartStreamAsync(ClassA classA, ClassB classB)
        {
            return GetResponseFor(() => StartStream(classA, classB));
        }
        
        public Task<ResponseBase> PrepareStreamAsync(ClassA classA, ClassB classB)
        {
            return GetResponseFor(() => PrepareStream(classA, classB));
        }
        
        public Task<ResponseBase> GetResponseFor(Func<ResponseBase> action)
        {
            _actionsDict.Add(action);
            var index = _actionsDict.Count - 1;
            
            return Task.Run<ResponseBase>(() => {
                while (_index < index) {
                    Thread.Sleep(100);
                }
                                
                Thread.Sleep(1000);
                Console.WriteLine("GetResponseFor -- {0}", _index);
                return _actionsDict[_index++]();
            });
        }
        
        ResponseBase StartStream(ClassA classA, ClassB classB)
        {
            Console.WriteLine("Start stream...");
            return new ResponseBase();
        }
        
        ResponseBase PrepareStream(ClassA classA, ClassB classB)
        {
            Console.WriteLine("Preparing stream...");
            return new ResponseBase();
        }
    }
