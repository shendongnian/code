            // new method body, returns byte array
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(string.Join(",", columnNames));
                foreach (var user in users)
                {
                    var row = leaderboard.Metrics.Select(m => Faker.RandomNumber.Next().ToString()).ToList();
                    row.Insert(0, user.UserName);
                    writer.WriteLine(string.Join(",", row));
                }
                writer.Flush();
                stream.Position = 0;
            }
            return stream.ToArray();
            // consumer opens a new stream using the bytes
            using (var stream = new MemoryStream(this.GetCSVStream(leaderboard, users)))
            {
                mockFile.Setup(f => f.InputStream).Returns(stream);
                this.service.UpdateEntries(update.ID, mockFile.Object);
            }
