            using (var db = new SQLiteConnectionWithLock(base.DatabasePath))
            {
                var result = db.Table<VideoUploadChunk>()
                    .Where(c => c.VideoId == videoId)
                    .ToList();
                return result.Select(c => c.ChunkNumber);
            }
