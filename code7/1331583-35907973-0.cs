    using System.Collections.Generic;
    using FileHelpers;
    
    ....
    private void Save<T>(string destFilename,  IEnumerable<T> data) where T : class    
    {
        var engine = new FileHelperEngine<T>();
        engine.HeaderText = engine.GetFileHeader(); 
        engine.WriteFile(destFilename, data);
    }
