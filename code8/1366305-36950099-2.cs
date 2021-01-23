    // Summary:
    //     Provides support for lazy initialization.
    //
    // Type parameters:
    //   T:
    //     Specifies the type of object that is being lazily initialized.
    public class Lazy<T> {
        // Summary:
        //     Initializes a new instance of the System.Lazy<T> class. When lazy initialization
        //     occurs, the default constructor of the target type is used.
        public Lazy();
        //
        // Summary:
        //     Initializes a new instance of the System.Lazy<T> class. When lazy initialization
        //     occurs, the specified initialization function is used.
        //
        // Parameters:
        //   valueFactory:
        //     The delegate that is invoked to produce the lazily initialized value when
        //     it is needed.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     valueFactory is null.
        public Lazy(Func<T> valueFactory);
    }
