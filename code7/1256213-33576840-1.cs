    // This code ...
    var thing = new Thing();
    using( thing ) {
        thing.DoOperation();
    }
    // ... turns into this code
    var thing = new Thing();
    try {
        thing.DoOperation();
    }
    finally {
        thing.Dispose();
        // Note the lack of a null assignment.
    }
