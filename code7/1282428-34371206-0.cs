    try
    {
        read = _serialPort.ReadLine().Replace(".", ",").Split('\r')[0];
    }
    catch (System.IO.IOException error)
    {
        return;
    }
    catch (System.InvalidOperationException error)
    {
        return;
    }
