    if (e.Type == Opcode.Text) {
      // Do something with e.Data.
      ...
    
      return;
    }
    
    if (e.Type == Opcode.Binary) {
      // Do something with e.RawData.
      ...
    
      return;
    }
