    bool available = true;
    try {
        UrlMkGetSessionOption(...test parameters...);
    }
    catch (DllNotFoundException)
    {
        available = false;
    }
    catch (EntryPointNotFoundException)
    {
        available = false;
    }
