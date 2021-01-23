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
             if (_IsFixing || _IsFixed)
                 return;
             _IsFixing = true;
        }
            // fix it
          
            _IsFixing = false;
            _IsFixed = true;
        }
    }
