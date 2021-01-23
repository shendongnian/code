    public static string PopulateOriginCombo(CableID_CreateView CView)
    {
       if(CView != null)
       {
           if (CView.cmbAreaCode.Text != "")
          {
             return CView.Text ;
          }
      }
      
      return string.Empty;
    }
