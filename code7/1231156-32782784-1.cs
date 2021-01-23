    public interface IParser 
    {
        Message parseFrom(byte[] data);
    }
    public readonly Dictionary<int, IParser>  parsersByKey= new Dictionary<int, IParser>
    {
        {1, new HiMessageParser() }
    };
