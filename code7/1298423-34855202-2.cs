    public class ToBeSerialized
    {
        // [...]
        
        // this is probably superflous if the callbacks do what you want, you can move the code there
        public SupportsInitialize SupportsInitialize { get; set; }
        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            this.SupportsInitialize.BeginInit();
        }
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            this.SupportsInitialize.EndInit();
        }
    }
