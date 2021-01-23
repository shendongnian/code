    class Program
    {
        static void Main(string[] args)
        {
            new Program().TimerCallback();
        }
        public Task<string> ReadSensorsAsync(string cell)
        {
            return Task.Run(() =>
            {
                if(cell == null) throw new ArgumentNullException();
                return cell;
            });
        }
        public Task<string> RecordReadingAsync(IEnumerable<string> cell)
        {
            return Task.Run(() =>
            {
                return string.Join(",", cell);
            });
        }
        public async void TimerCallback()
        {
            try
            {
                var tasksRead = new string[] { "1", null, "3" }.Select(s => ReadSensorsAsync(s));
                var taskRecordResult = await RecordReadingAsync(await Task.WhenAll(tasksRead));
                Debugger.Log(1, "test", taskRecordResult);
            }
            catch (Exception e)
            {
                //catches here
                Debugger.Log(1, "test", e.Message ?? e.ToString());
            }
        }
    }
