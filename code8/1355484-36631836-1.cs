        public async SaveToFile()
    {
    
        IRandomAccessStream audio = buffer.CloneStream(); //your recoreded InMemoryRandomAccessStream
	 	var folder  = KnownFolders.MusicLibrary.CreateFolderAsync("MyCapturedAudio", CreationCollisionOption.OpenIfExists);
	 	outputFile = await folder.CreateFileAsync("record.mp3", CreationCollisionOption.GenerateUniqueName);
            using (IRandomAccessStream fileStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                await RandomAccessStream.CopyAndCloseAsync(audio.GetInputStreamAt(0), fileStream.GetOutputStreamAt(0));
                await audio.FlushAsync();
                audio.Dispose();
            }
        });
    }
