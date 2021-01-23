    public static async Task ParseResponse(String response, Frame frame)
        {
            await Task.Run(() =>
            {
                SingleTank parsedTanks = JsonConvert.DeserializeObject<SingleTank>(response);
            });
            // UI code by calling the dispatcher
        }
