       public static class Shared
        {
            public static string property = "something..";
    
            public static async Task<bool> Method()
            {
                await Task.Delay(400);
                return false;
            }
        }
