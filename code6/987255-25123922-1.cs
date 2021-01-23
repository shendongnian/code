    public void Update()
    {
       _currentModsLength = 0;
       // copy over!!
       lock(_activeMods){
          _currentModsLength = _activeMods.Length;
          for(var i = 0; i < _currentModsLength; i++){
             _mods[i] = _activeMods[i];
          }
       }
    
       for(var k = 0; k < _currentModsLength; k++)
          _mods[k].Update(..);
    }
