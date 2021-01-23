    public interface IParser 
    {
        Message parseFrom(byte[] data);
    }
    public readonly Map<int, IParser>  parsersByKey= new HashMap
    {
        {1, new HiMessageParser() }
    };
