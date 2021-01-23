        [TestClass]
        public class UnitTest1
        {
          [TestMethod]
          public void TestMethod1()
          {
            Assert.AreEqual(true, ChangeEventStatus(new EventData() {EventId = 3}));
          }
          private static bool ChangeEventStatus(EventData eventData)
          {
              int updatedRows = 0;
              using (var cn = new OleDbConnection("Provider=sqloledb;Data Source=localhost;Initial Catalog=FastExperiments;User Id = sa; Password = pass; "))
              {
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cn.Open();
                    cmd.CommandText = "Update EventList Set IsProcessed = ? Where EventId = ?";
                    cmd.Parameters.Add("IsProcessed", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("EventId", OleDbType.BigInt).Value = eventData.EventId;
                    updatedRows = cmd.ExecuteNonQuery();
                }
              }
              return (updatedRows == 1);
          }
          private class EventData
          {
            public int EventId { get; set; }
          }
        }
