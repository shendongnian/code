    class Game
    {
        private readonly ILogger _logger;
        public Game(ILogger logger)
        {
            _logger = logger;
        }
        public void Start()
        {
            _logger.StartWriting();
        }
        public void SaveDataFeedback()
        {
            var dataobject = new GameData();
            // filling data object
            _logger.WriteData(dataobject);
        }
    }
    internal interface ILogger
    {
        void StartWriting();
        void WriteData(GameData data);
    }
    public class GameData
    {
        public double PositionRingFeeback { get; set; }
        public double PositionSphereMiddle { get; set; }
        public double DistanceRingFeedbackToSphere { get; set; }
        public int Collisions { get; set; }
        public TimeSpan Timer { get; set; }
    }
    class FileLogger : ILogger, IDisposable
    {
        private readonly string _filename;
        private StreamWriter _sr;
        public FileLogger(string filename)
        {
            _filename = filename;
        }
        public void StartWriting()
        {
            _sr = new StreamWriter(new FileStream(_filename, FileMode.OpenOrCreate), Encoding.UTF8);
            _sr.WriteLine("PositionRingFeeback" + "," + "PositionSphereMiddle" + "," + "distanceRingFeedbackTOSphere" + "," + "Collisions" + "," + "Timer");
        }
        public void WriteData(GameData data)
        {
            _sr.Write("{0}{1}{2}{3}{4}", data.PositionRingFeeback, data.PositionSphereMiddle, data.DistanceRingFeedbackToSphere, data.Collisions, data.Timer);
        }
        public void Dispose()
        {
            _sr.Dispose();
        }
    }
