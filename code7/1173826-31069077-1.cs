    public void Abort()
    {
        if (request != null)
        {
            try 
            { 
                request.ReadWriteTimeout = 0; } catch { }
                request.Timeout = 0;
                request.Abort(); 
            } catch {//Some error}
        }
    }
