        public static async Task<bool> Task1()
        {
             await Task.Delay(10000);
             return true;
        }
        public static async Task<bool> Task2()
        {
             Task.Delay(10000);
             return true;
        }
