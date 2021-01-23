            for (int i = 0; i < num; i++)
            {
                int c = i;
                tasks[i] = RunAsync(c);
            }
            await Task.WhenAll(tasks);
