    public interface ISomePublicInterface
    {
        int GetValue();
    }
    internal class InternalClass : ISomePublicInterface
    {
        public int GetValue()
        {
            return 100;
        }
    }
    public static class SomeFactory
    {
        public static ISomePublicInterface GetInternalInstanceAsInterface()
        {
            return new InternalClass();
        }
    }
