    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace EF.CodeFirst
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (var db = new TestDbContext())
                {
                    var taskId = 1;
                    var query = from job in db.JobRecordHistories
                        where job.TaskId == taskId
                        orderby job.TimeOfRun descending
                        group job by job.DeviceId
                        into deviceGroup
                        select deviceGroup;
                    foreach (var deviceGroup in query)
                    {
                        foreach (var jobRecordHistory in deviceGroup)
                        {
                            Console.WriteLine("DeviceId '{0}', TaskId'{1}' Runtime'{2}'", jobRecordHistory.DeviceId,
                                jobRecordHistory.TaskId, jobRecordHistory);
                        }
                    }
                }
            }
        }
        public class TestDbContext : DbContext
        {
            public DbSet<JobRecordHistory> JobRecordHistories { get; set; }
        }
        public class JobRecordHistory
        {
            public int Id { get; set; }
            public int TaskId { get; set; }
            public int DeviceId { get; set; }
            public DateTime TimeOfRun { get; set; }
        }
    }
