    [Serializable]
    public abstract class AbstractInfo<T>
    {
        object[] Data;
        protected AbstractInfo(int tableSize)
        {
            Data = new object[tableSize];
        }
        protected object GetValue(int index)
        {
            return Data[index];
        }
        protected void SetValue(int index, object value)
        {
            Data[index] = value;
        }
    }
    [Serializable]
    public class MediaInfo : AbstractInfo<MediaInfo>
    {
        public MediaInfo() : base(1) { }
        public virtual string MediaPanel
        {
            get
            {
                return (string)GetValue(0) ?? string.Empty;
            }
            set
            {
                SetValue(0, value == "" ? null : value);
            }
        }
    }
