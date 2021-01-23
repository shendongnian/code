    void SomeLongRunningMethod()
    {
        try
        {
            Method1();
            if (Method2())
            {
                Method3();
            }
            var somedata = Method4();
        }
        catch (InvalidOperationException invEx) when (invEx.TargetSite?.Name == nameof(Method1))
        {
            // ...
        }
        catch (InvalidOperationException invEx) when (invEx.TargetSite?.Name == nameof(Method2))
        {
            // ...
        }
        catch (Exception ex)
        {
            // ...
        }
    }
