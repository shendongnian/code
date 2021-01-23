     static async Task<Program> GetAsync()
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    return await Task.FromException<Program>(e);
                }
            }
