    public interface Iface
    {
        // TODO: Add non type specific methods here
    }
    public interface Iface<TIface> : Iface
        where TIface : Iface<TIface>
    {
        Function<Some, Some> Updater(Func<TIface, TIface> op);
    }
    public class Test : Iface<Test>
    {
        public Function<Some, Some> Updater(Func<Test, Test> op)
        {
            // Use op with parameters that are of type Test
            return null;
        }
    }
