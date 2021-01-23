    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Table;
    
    namespace MyFunctions
    {
        public class StorageTable : TableEntity
        {
            public StorageTable()
            {
            }
            public StorageTable(string PKey, string RKey)
            {
                PartitionKey = PKey;
                RowKey = RKey;
            }
    
            public DateTime EnqueuedTime { get; set; }
            public Int64 Sequence { get; set; }
            public string Offset { get; set; }
        }
    }
