        public abstract class EntityData : ITableData
        {
         //Change the constructor to initilaize required filled with meaningful data.
            protected EntityData()
            {
              Id=Guid.NewGuid().ToString();
              CreatedDate=DateTime.UtcNow;
              UpdatedDate=DateTime.UtcNow;
            }
        
            [Index(IsClustered = true)]
            [TableColumn(TableColumnType.CreatedAt)]
            public DateTimeOffset? CreatedAt { get; set; }
            [TableColumn(TableColumnType.Deleted)]
            public bool Deleted { get; set; }
            [TableColumn(TableColumnType.Id)]
            public string Id { get; set; }
            [TableColumn(TableColumnType.UpdatedAt)]
            public DateTimeOffset? UpdatedAt { get; set; }
            [TableColumn(TableColumnType.Version)]
            public byte[] Version { get; set; }
        }
