    private void button1_Click(object sender, EventArgs e)
        {
            var list = GetDatabaseAsync();
            //do whatever you need with the list.
        }
        
        private async Task<List<string>>  GetDatabaseAsync()
        {
            var list = Task.Run(() =>
            {
                var _observablecollectionname = new List<string>();
                var GotData = Helper.GetData();
                _observablecollectionname.Clear();
                foreach (var item in GotData)
                {
                    _observablecollectionname.Add(item);
                }
                return _observablecollectionname;
            });
            return await list;
        }
