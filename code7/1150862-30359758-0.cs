        public interface IMedia
        {
            object Content { get; }
            double RecordingLength { get; }
        }
        public interface IWritableMedia : IMedia
        {
            void SetContent(object content);
            void SetRecordingLength(double length);
        }
