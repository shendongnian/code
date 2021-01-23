                    videoUrl = ((AVFoundation.AVUrlAsset)avAsset).Url;
                    NSError assetReaderError;
                    var assetReader = AVAssetReader.FromAsset(avAsset, out assetReaderError);
                    var assetTrack = avAsset.Tracks.First();
                    //Height = (System.nint?)avAsset.NaturalSize.Height,
                        //Width = (System.nint?)avAsset.NaturalSize.Width,
                   var inputSettings = new AVVideoSettingsUncompressed()
                   {
                        Height = (System.nint?)avAsset.NaturalSize.Height,
                        Width = (System.nint?)avAsset.NaturalSize.Width,
                   };
                   var assetReaderOutput = new AVAssetReaderTrackOutput(assetTrack, settings: inputSettings);
                   assetReaderOutput.AlwaysCopiesSampleData = false;
                   string tempFile = Path.Combine(Path.GetTempPath(), "CroppedVideo.mp4");
                   if (File.Exists(tempFile)) File.Delete(tempFile);
                   var url = NSUrl.FromFilename(tempFile);
                   NSError assetWriterError;
                   var assetWriter = new AVAssetWriter(url, AVFileType.Mpeg4, out assetWriterError);
                   var outputSettings = new  AVVideoSettingsCompressed()
                   {
                       Height = 300,
                       Width = 300,
                        Codec = AVVideoCodec.H264,
                       CodecSettings = new AVVideoCodecSettings()
                       {
                           AverageBitRate = 1000000, 
                            VideoCleanAperture = new AVVideoCleanApertureSettings(
                                new NSDictionary(
                                AVVideo.CleanApertureWidthKey, new NSNumber(300),
                                AVVideo.CleanApertureHeightKey, new NSNumber(300),
                                AVVideo.CleanApertureVerticalOffsetKey, new NSNumber(10),
                                AVVideo.CleanApertureHorizontalOffsetKey, new NSNumber(10)
                                )
                            )    
                       }, 
                         
                        ScalingMode = AVVideoScalingMode.ResizeAspectFill
                   };
                    var assetWriterInput = new AVAssetWriterInput(mediaType: AVMediaType.Video, outputSettings: outputSettings);
                    assetWriterInput.ExpectsMediaDataInRealTime = false;
                   assetWriter.AddInput(assetWriterInput);
                   assetWriter.StartWriting();
                   assetReader.AddOutput(assetReaderOutput);
                   assetReader.StartReading();
                   assetWriter.StartSessionAtSourceTime(CoreMedia.CMTime.Zero);
                   var mediaInputQueue = new DispatchQueue("mediaInputQueue");
                   assetWriterInput.RequestMediaData(mediaInputQueue, () =>
                   {
                       while (assetWriterInput.ReadyForMoreMediaData)
                       {
                           var nextBuffer = assetReaderOutput.CopyNextSampleBuffer();
                           if (nextBuffer != null)
                           {
                               assetWriterInput.AppendSampleBuffer(nextBuffer);
                           }
                           else
                           {
                               assetWriterInput.MarkAsFinished();
                               assetWriter.FinishWritingAsync();
                               assetReader.CancelReading();
                               assetReader.Dispose();
                               assetReaderOutput.Dispose();
                               assetWriter.Dispose();
                               assetWriterInput.Dispose();
                               break;
                           }
                       }
                   });
                }
