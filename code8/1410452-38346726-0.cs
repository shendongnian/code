    [XmlRoot("Entity")]
    public class StoreItem<TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets and sets the status of the entity when storing.
        /// </summary>
        [XmlAttribute]
        public System.Data.Services.Client.EntityStates Status { get; set; }
        /// <summary>
        /// Gets and sets the entity to be stored.
        /// </summary>
        [XmlIgnore]
        public TEntity Entity { get; set; }
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement XmlEntity
        {
            get
            {
                return (Entity == null ? null : XObjectExtensions.SerializeToXElement(Entity, null, true));
            }
            set
            {
                Entity = (value == null ? null : XObjectExtensions.Deserialize<TEntity>(value));
            }
        }
    }
