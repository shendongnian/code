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
            using (var client = new Amazon.S3.AmazonS3Client(accessKey, secretKey, S3Config))
            {
                PutObjectRequest request = new PutObjectRequest { BucketName = "videoToconvert", CannedACL = S3CannedACL.PublicRead, Key = filePath, InputStream = fs }; 
                client.PutObject(request);
            }
            String finalOriginalPath = AMAZON_ROOT + filePath;
            finalOriginalPath = finalOriginalPath.Replace("+", "%2B");
            var etsClient = new AmazonElasticTranscoderClient(accessKey, secretKey, S3Config.RegionEndpoint);
            var notifications = new Notifications()
            {
                Completed = "arn:aws:sns:us-west-2:277579135337:Transcode",
                Error = "arn:aws:sns:us-west-2:277579135337:Transcode",
                Progressing = "arn:aws:sns:us-west-2:277579135337:Transcode",
                Warning = "arn:aws:sns:us-west-2:277579135337:Transcode"
            };
            var pipeline = new Pipeline();
            if (etsClient.ListPipelines().Pipelines.Count() == 0)
            {
                pipeline = etsClient.CreatePipeline(new CreatePipelineRequest()
                {
                    Name = "MyTranscodedVideos",
                    InputBucket = "videoToconvert",
                    OutputBucket = "videoToconvert",
                    Notifications = notifications,
                    Role = "arn:aws:iam::277579135337:role/Elastic_Transcoder_Default_Role",
                }).Pipeline; //createpipelineresult
            }
            else
            {
                pipeline= etsClient.ListPipelines().Pipelines.First();
            }
            
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
                    ThumbnailPattern = "thumbnnail{count}",
                    Rotate = "0",
                    PresetId = "1351620000001-000010", //Generic-720 px
                    Key = finalOriginalPath
                }
            });
           
            using (var delClient = new Amazon.S3.AmazonS3Client(accessKey, secretKey, S3Config))
            {
                //delClient.DeleteObject("VideoToConvert", filePath);
            }
            return finalOriginalPath;
        }
