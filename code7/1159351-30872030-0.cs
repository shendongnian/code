    if (Instance == null) return;
    
      try
      {
        string scriptExtension = ".myext";
        var itemOp = Instance.GetDTE2().ItemOperations;
        const string fileNameBase = "NewFile1";
        itemOp.NewFile(@"General\Text File", fileNameBase + scriptExtension, "{00000000-0000-0000-0000-000000000000}");
      }
      catch (Exception ex)
      {
        MessageBox.Show("An error ocurred. " + ex.Message);
      }
