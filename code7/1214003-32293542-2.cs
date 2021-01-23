    public interface Iface
    {
        // TODO: Add non type specific methods here
    }
    public interface Iface<TIface> : Iface
        where TIface : Iface<TIface>
    {
        // Type specific methods get defined here
        Function<Some, Some> Updater(Func<TIface, TIface> op);
    }
    public class Test : Iface<Test> // <- We're implementing the generic version of Iface<TIface> instead of Iface.  Note that Iface<TIface> extends Iface, so this class must implement that interface too.
    {
        public Function<Some, Some> Updater(Func<Test, Test> op)
        {
            // Use op with parameters that are of type Test
            return null;
        }
    }
