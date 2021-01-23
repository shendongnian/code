    public async Task<IStorageFile> ConcatenateAudio([ReadOnlyArray]IStorageFile[] audioFiles, IStorageFolder outputFolder, string outputfileName)
        {
            IStorageFile _OutputFile = await outputFolder.CreateFileAsync(outputfileName, CreationCollisionOption.ReplaceExisting);
            MediaComposition _MediaComposition = new MediaComposition();
            MediaEncodingProfile _MediaEncodingProfile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.High);
            TimeSpan totalDelay = TimeSpan.Zero;
            foreach (IStorageFile _AudioFile in audioFiles)
            {
                if (_AudioFile != null)
                {
                    BackgroundAudioTrack _BackgroundAudioTrack = await BackgroundAudioTrack.CreateFromFileAsync(_AudioFile);
                    
                    MediaClip _MediaClip = MediaClip.CreateFromColor(Windows.UI.Colors.Black, _BackgroundAudioTrack.TrimmedDuration); // A dummy black video is created witn the size of the current audio chunk. 
                                                                                                                                      // Without this, the duration of the MediaComposition object is always 0. 
                                                                                                                                      // It's a messy workaround but it gets the job done. 
                                                                                                                                      // Windows 10 will dirrectly support PauseRecordAsync() and ResumeRecordAsync() for MediaCapture tho'. Yay! :D
                    _MediaClip.Volume = 0;
                    _BackgroundAudioTrack.Volume = 1;
                    _MediaComposition.Clips.Add(_MediaClip);
                    _MediaComposition.BackgroundAudioTracks.Add(_BackgroundAudioTrack);
                    _BackgroundAudioTrack.Delay = totalDelay;
                    totalDelay += _BackgroundAudioTrack.TrimmedDuration;
                }
            }
            TranscodeFailureReason _TranscodeFailureReason = await _MediaComposition.RenderToFileAsync(_OutputFile, MediaTrimmingPreference.Fast, _MediaEncodingProfile);
            if (_TranscodeFailureReason != TranscodeFailureReason.None)
            {
                throw new Exception("Audio Concatenation Failed: " + _TranscodeFailureReason.ToString());
            }
            return _OutputFile;
        }
