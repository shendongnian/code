        try 
        {
            DoWork(x)
        }
        catch (ParticularException pex)
        {
              FixParticularException(pex);
        }        
        DoSomething(x);   
    }        
    private void FixParticularException (ParticularException pex)
    {
        lock (_resource1Lock)
        {
             if (_IsFixed)
                 return;
            // fix it
          
            _IsFixed = true;
        }
    }
