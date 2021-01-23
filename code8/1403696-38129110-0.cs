    public string UploadVideoToLocation(Stream fs, String folder, String subFolder, String filename)
            {
                string accessKey = this.accessKey;
                string secretKey = this.secretKey;
    
                filename = filename.Replace("+", "");
                String filePath = folder.Replace("+", "") + "/" + subFolder.Replace("+", "") + "/" + Guid.NewGuid() + filename;
                if (Path.GetExtension(filePath).IsNullOrEmpty())
                {
                    filePath += ".mp4";
                }
    
                String finalOriginalPath = AMAZON_ROOT + filePath;
                finalOriginalPath = finalOriginalPath.Replace("+", "%2B");
    
                var etsClient = new AmazonElasticTranscoderClient(accessKey, secretKey, S3Config.RegionEndpoint);
    
                var notifications = new Notifications()
                {
                    Completed = "arn:aws:sns:us-east-1:XXXXXXXXXXXX:Transcode",
                    Error = "arn:aws:sns:us-east-1:XXXXXXXXXXXX:Transcode",
                    Progressing = "arn:aws:sns:us-east-1:XXXXXXXXXXXX:Transcode",
                    Warning = "arn:aws:sns:us-east-1:XXXXXXXXXXXX:Transcode"
                };
    
                var pipeline = etsClient.CreatePipeline(new CreatePipelineRequest()
                {
                    Name = "MyTranscodedVideos",
                    InputBucket = "VideoToConvert",
                    OutputBucket = "VideoToConvert",
                    Notifications = notifications,
                    Role = "arn:aws:iam::XXXXXXXXXXXX:role/Elastic_Transcoder_Default_Role"
                }).Pipeline; //createpipelineresult
                
                etsClient.CreateJob(new CreateJobRequest()
                {
                    PipelineId = pipeline.Id,
                    Input = new JobInput()
                    {
                        AspectRatio = "auto",
                        Container = "mp4", //H.264
                        FrameRate = "auto",
                        Interlaced = "auto",
                        Resolution = "auto",
                        Key = filePath
                    },
                    Output = new CreateJobOutput()
                    {
                        ThumbnailPattern = filename,
                        Rotate = "0",
                        PresetId = "1351620000001-000010", //Generic-720 px
                        Key = finalOriginalPath
                    }
                });
               
                using (var delClient = new Amazon.S3.AmazonS3Client(accessKey, secretKey, S3Config))
                {
                    delClient.DeleteObject("VideoToConvert", filePath);
                }
    
                return finalOriginalPath;
            }
