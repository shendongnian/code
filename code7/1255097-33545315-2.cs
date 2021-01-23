    class IThingFactory
    {
        public IThing MakeThing<T>() where T : IThing, new()
        {
             var thing = new T();
             thing.Init(); // has to be part of the IThing interface.
             return thing;
        }
    }
