        MediaEncodingProfile _Profile = Windows.Media.MediaProperties.MediaEncodingProfile.CreateMp3(AudioEncodingQuality.High);
        MediaTranscoder _Transcoder = new Windows.Media.Transcoding.MediaTranscoder();
        CancellationTokenSource _cts = new CancellationTokenSource();
        private void ConvertSteamToMp3()
        {
            IRandomAccessStream audio = buffer.CloneStream(); //your recoreded InMemoryRandomAccessStream
            var folder = KnownFolders.MusicLibrary.CreateFolderAsync("MyCapturedAudio", CreationCollisionOption.OpenIfExists);
            outputFile = await folder.CreateFileAsync("record.mp3", CreationCollisionOption.GenerateUniqueName);
            using (IRandomAccessStream fileStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                var preparedTranscodeResult = await _Transcoder.PrepareStreamTranscodeAsync(audio, fileStream, _Profile);
                if (preparedTranscodeResult.CanTranscode)
                {
                    var progress = new Progress<double>(TranscodeProgress);
                    await preparedTranscodeResult.TranscodeAsync().AsTask(_cts.Token, progress);
                }
                using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                {
                    using (DataWriter dataWriter = new DataWriter(outputStream))
                    {
                        //TODO: Replace "Bytes" with the type you want to write.
                        dataWriter.WriteBytes(bytes);
                        await dataWriter.StoreAsync();
                        dataWriter.DetachStream();
                    }
                    await outputStream.FlushAsync();
                }
            }
        }
