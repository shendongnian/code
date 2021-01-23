    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
    
        mimg.Dispose(); // mimg should be global, of course
      }
    
      base.Dispose(disposing);
    }
