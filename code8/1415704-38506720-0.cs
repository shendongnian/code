        public async Task WriteDataAsync(string fileName, string data)
        {
            byte[] text = Encoding.Unicode.GetBytes(data);
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await stream.WriteAsync(text, 0, text.Length);
            };
        }
