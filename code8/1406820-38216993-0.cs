        public static async Task<Scenario> Test()
        {
            return await new AsyncScenario();
        }
        public class AsyncScenario
        {
            public TaskAwaiter<Scenario> GetAwaiter()
            {
                return new TaskAwaiter<Scenario>();
            }
        }
