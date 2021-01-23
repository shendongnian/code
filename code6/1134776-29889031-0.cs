            Task<String> task1 = readFromReader1();
            Task<String> task2 = readFromReader2();
            String result;
            Task.WaitAny(new Task[]{task1, task2});
            if (task1.IsCompleted)
            {
                result = task1.Result;
            }
            else
            {
                result = task2.Result;
            }
