    // '\'' is a separator, you have no need to put it twice
    // but put StringSplitOptions.RemoveEmptyEntries
    // so empty lines created by doubled ampersands
    // ''abc'' -> ["" , "abc", ""]
    // will be removed
    string result1 = test1
      .Split(new Char[] { '\'', }, StringSplitOptions.RemoveEmptyEntries)[3];
    string result2 = test2
      .Split(new Char[] { '\'', }, StringSplitOptions.RemoveEmptyEntries)[3];
