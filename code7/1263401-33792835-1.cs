    [Serializable]
    public class Ball
    {
        public Ball()
        {
            Points = new List<int>() { 1 };
            IsEnabled = false;
        }
        public bool IsEnabled { get; set; }
        [XmlIgnore]
        public List<int> Points { get; set; }
        [XmlArray("Points")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int[] SerializablePoints
        {
            get
            {
                return (Points == null ? null : Points.ToArray());
            }
            set
            {
                Points = ListExtensions.Initialize(Points, value);
            }
        }
    }
    public static class ListExtensions
    {
        public static List<T> Initialize<T>(List<T> list, T[] value)
        {
            if (value == null)
            {
                if (list != null)
                    list.Clear();
            }
            else
            {
                (list = list ?? new List<T>(value.Length)).Clear();
                list.AddRange(value);
            }
            return list;
        }
    }
