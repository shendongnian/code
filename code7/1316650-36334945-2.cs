    [TestClass]
    public class RejectDataColumnChanges
    {
        private bool isRevertingChanges;
    
        private const string TestColumn1 = "testColumn1";
        private const string TestColumn2 = "testColumn2";
        private const string TestColumn2Backup = "testColumn2Backup";
    
        private const string PreservedMessage = "This change should be preserved";
        private const string RejectedMessage = "This change should be rejected";
    
        [TestMethod]
        public void RejectDataColumnChangesTest()
        {
            DataTable table = new DataTable("testTable1");
            table.Columns.Add(TestColumn1);
            table.Columns.Add(TestColumn2);
    
            DataRow row = table.NewRow();
            row[TestColumn1] = PreservedMessage;
            row[TestColumn2] = PreservedMessage;
            table.Rows.Add(row);
    
            table.ColumnChanging += OnColumnChanging;
    
            row[TestColumn2] = RejectedMessage;
    
            Assert.AreEqual(PreservedMessage, row[TestColumn1]);
            Assert.AreEqual(RejectedMessage, row[TestColumn2]);
            Assert.AreEqual(PreservedMessage, row[TestColumn2Backup]);
    
            if (true)
            {
                isRevertingChanges = true;
                row[TestColumn2] = row[TestColumn2Backup];
                isRevertingChanges = false;
            }
    
            Assert.AreEqual(PreservedMessage, row[TestColumn1]);
            Assert.AreEqual(PreservedMessage, row[TestColumn2]);
            Assert.AreEqual(PreservedMessage, row[TestColumn2Backup]);
        }
    
        void OnColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (!isRevertingChanges && e.Column.ColumnName.Equals(TestColumn2))
            {
                if (!e.Row.Table.Columns.Contains(TestColumn2Backup))
                    e.Row.Table.Columns.Add(TestColumn2Backup);
    
                e.Row[TestColumn2Backup] = e.Row[TestColumn2];
            }
        }
    }
