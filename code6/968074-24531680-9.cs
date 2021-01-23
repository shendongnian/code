    public class ConsumerOfOriginal
    {
        public void ConsumeOriginal(Original original);
    }
    Original original = new Original();
    OriginalWrapper originalWrapper = new OriginalWrapper(original);
    Consumer consumer = new ConsumerOfOriginal();
    consumer.ConsumeOriginal(original); // Compiles and works
    consumer.ConsumeOriginal(originalWrapper); // Fails to compile
