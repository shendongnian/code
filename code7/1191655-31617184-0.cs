        internal static async Task<bool> iASK(string message, string title)
        {
               return await Application.Current.Dispatcher.Invoke(async () =>
               {
                    return await ASK(message, title);
               });
        //throw new Exception("iASK's question didn't receive response.");
        }
