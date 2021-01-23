    public interface IGamePersistanceProvider
    {
        void Save(Game game);
    }
    public class TextFilePersistanceProvider : IGamePersistanceProvider
    {
        private IConfigurationProvider _configurationProvider;
        public TextFilePersistanceProvider(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public void Save(Game game)
        {
            if (game == null) { throw new ArgumentException("Unexpected parameter"); }
            var filePath = _configurationProvider.GetValue<string>("LatestGamePath");
            var gameAsJson = JsonConvert.SerializeObject(game, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(filePath, gameAsJson);
        }
    }
    public class S3PersistanceProvider : IGamePersistanceProvider
    {
        private IConfigurationProvider _configurationProvider;
        public S3PersistanceProvider(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public void Save(Game game)
        {
            if (game == null) { throw new ArgumentException("Unexpected parameter"); }
            var gameAsJson = JsonConvert.SerializeObject(game, Formatting.None, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
            string accessKey = _configurationProvider.GetValue<dynamic>("S3Credentials").AccessKey.ToString();
            string secretKey = _configurationProvider.GetValue<dynamic>("S3Credentials").SecretKey.ToString();
            string bucketName = _configurationProvider.GetValue<dynamic>("S3Credentials").BucketName.ToString();
            string key = game.Name;
            using (var s3Client = new AmazonS3Client(new BasicAWSCredentials(accessKey, secretKey), RegionEndpoint.EUWest1))
            {
                var transferUtil = new TransferUtility(s3Client);
                var memStream = new MemoryStream(Encoding.UTF8.GetBytes(gameAsJson));
                transferUtil.Upload(memStream, bucketName, key);
            }
        }
    }
