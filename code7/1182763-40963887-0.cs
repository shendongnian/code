            using (var db = new SQLiteConnectionWithLock(base.DatabasePath))
            {
                return db.Table<VideoUploadChunk>()
                    .Where(c => c.VideoId == videoId)
                    .Select(c => c.ChunkNumber)
                    .ToList();
            }
