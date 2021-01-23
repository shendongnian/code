    // The legacy savegame data
    [Serializable]
    public class Savegame: IObjectReference
    {
        // ... the legacy fields
        public object GetRealObject(StreamingContext context)
        {
            return new SavegameNew(...);
        }
    }
