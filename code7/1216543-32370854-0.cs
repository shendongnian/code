    private _contentSourceVm;
    prop ContentSourceVm
    {
      get
       {
         return _contentSourceVm;
       }
      set
       {
         IDisposable disp=_contentSourceVm as IDisposable ;
         if(disp!=null)
         {
          disp.Dispose();
         }
         _contentSourceVm=value;
         OnpropertyChnaged();
       }
    }
