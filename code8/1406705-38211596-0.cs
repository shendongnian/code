        public class SchemaItem
        {
            public int Index;
            public string ColumnName;
            public int ParsedValue;
            public SchemaItem(int index, string columnName)
            {
                Index = index;
                ColumnName = columnName;
            }
        }
        public static Dictionary<int, SchemaItem> Schema = new Dictionary<int, SchemaItem>
        {
            {0, new SchemaItem(0, "facilityID")},
            {1, new SchemaItem(1, "facilityDockDoorID")},
            {2, new SchemaItem(2, "increment")},
            {3, new SchemaItem(3, "hoursOfOperationId")},
            {4, new SchemaItem(4, "updatedById")},
            {5, new SchemaItem(5, "startTime")},
            {6, new SchemaItem(6, "endTime")},
            {7, new SchemaItem(7, "dockDoorServiceType")},
            {8, new SchemaItem(8, "daysOfTheWeek")},
        };
        private static bool ParseIntAndOrWriteFailMessage(string[] row, StringBuilder logger, int index)
        {
            string cellContents = row[index];
            string columnName = Schema[index].ColumnName;
            int intContents = -1;
            if (int.TryParse(cellContents, out intContents))
            {
                Schema[index].ParsedValue = intContents;
                return true;
            }
            logger.AppendFormat("{0} is invalid,", columnName);
            return false;
        }
