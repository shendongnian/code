    public static class Runner
    {
        public static async Task<IEnumerable<ProcessWithResult>> RunAll(this IEnumerable<Task<ProcessWithResult>> tasks, bool runSequentially)
        {
            if (!runSequentially) return await Task.WhenAll(tasks);
            var results = new List<ProcessWithResult>();
            foreach (var task in tasks)
                results.Add(await task);
            return results;
        }
    }
    public class Tests
    {
        [Test]
        public void RunInParallel()
        {
            var results = GetAllTasks().RunAll(false).Result;
            CollectionAssert.AreEqual(new[] { 2, 1 }, results.OrderBy(r => r.WhenFinished).Select(r => r.Id));
        }
        [Test]
        public void RunInSequentially()
        {
            var results = GetAllTasks().RunAll(true).Result;
            CollectionAssert.AreEqual(new[] { 1, 2 }, results.OrderBy(r => r.WhenFinished).Select(r => r.Id));
        }
        IEnumerable<Task<ProcessWithResult>> GetAllTasks()
        {
            yield return RunTask(1, 1000);
            yield return RunTask(2, 100);
        }
        async Task<ProcessWithResult> RunTask(int id, int wait)
        {
            await Task.Delay(wait);
            return new ProcessWithResult {Id = id, WhenFinished = DateTime.Now};
        }
    }
    public class ProcessWithResult
    {
        public int Id { get; set; }
        public DateTime WhenFinished { get; set; }
    }
