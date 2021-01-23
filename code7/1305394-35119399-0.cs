        public async void editLineById(string fileName, string match, string content) {
            List<string> file = await readAllFromFile(fileName);
            int matchId = file.IndexOf(file.Where((item) => item.Contains(match)).First());
            file[matchId] = content;
            overrideFile(fileName, file);
        }
        public async Task<List<string>> readAllFromFile(string fileName) {
                List<string> content = new List<string>();
                using (StreamReader readStream = new StreamReader(await localFolder.OpenStreamForReadAsync(fileName))) {
                    while (readStream.Peek() != -1) {
                        content.Add(await readStream.ReadLineAsync());
                    }
                    readStream.Dispose();
                }
            return content;
        }
        public async void overrideFile(string fileName, List<string> content) {
            using (StreamWriter writeStream = new StreamWriter(await localFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))) {
                foreach(string line in content) {
                    await writeStream.WriteLineAsync(line);
                }
            }
        }
