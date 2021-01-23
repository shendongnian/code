    try {
        TheDatabase.Configuration.LazyLoadingEnabled = false;
        ...
        ...
    }
    finally {
        TheDatabase.Configuration.LazyLoadingEnabled = true;
    }
