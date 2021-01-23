    // The Empty constant holds the empty string value. It is initialized by the EE during startup.
    // It is treated as intrinsic by the JIT as so the static constructor would never run.
    // Leaving it uninitialized would confuse debuggers.
    . . . .
    public static readonly String Empty;
