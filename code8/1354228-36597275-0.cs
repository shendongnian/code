    bool available = true;
    try {
        UrlMkSetSessionOption(...test parameters...);
    }
    catch (DllNotFoundException)
    {
        available = false;
    }
    catch (EntryPointNotFoundException)
    {
        available = false;
    }
