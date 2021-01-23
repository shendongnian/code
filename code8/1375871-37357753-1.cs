    public class XmlReader
    {
        public bool IsScoreCard { get; set; }
    }
    public abstract class ImportRunner
    {
    }
    public class ScorecardRunner : ImportRunner
    {
    }
    public class DefaultRunner : ImportRunner
    {
    }
    public class RunnerFactory
    {
        private readonly XmlReader _reader;
        public RunnerFactory(XmlReader reader)
        {
            _reader = reader;
        }
        public ImportRunner Resolve()
        {
            if (_reader.IsScoreCard)
                return new ScorecardRunner();
            return new DefaultRunner();
        }
    }
