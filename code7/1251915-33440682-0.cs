    public class Unit
    {
        public long? ID { get; set; }
        public string Name { get; set; }
        public Unit Self { get { return this; } }
        public Unit(long id, string name)
        {
            ID = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Unit)
            {
                if ((obj as Unit).ID == this.ID && (obj as Unit).Name == this.Name) //* See Footnote
                {
                    return true;
                }
            }
            return base.Equals(obj);
        }
    }
