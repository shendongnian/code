        public static async Task<string> MyTask()
        {
            //C# anonymous AsyncTask
            return await Task.FromResult<string>(((Func<string>)(() =>
            {
                // your code here
                return  "string result here";
            }))());
        }
