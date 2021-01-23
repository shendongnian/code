    public  Task<int> GetData() {
            var result = new TaskCompletionSource<int>();
            result.SetResult(1);
            return result.Task;
    }
