      String source = 
        @"//
          //
          // Authors
          // Mr. Simmonsen 
          // Mr. Greg
          //
          //
          //";
    
      String result = String.Join(Environment.NewLine, source
        .Split(new String[] { Environment.NewLine }, StringSplitOptions.None)
        .Where(line => !line.Trim().Equals("//")));
