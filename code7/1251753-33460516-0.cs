    public class DataItem
    {
      int         _index ;
      double      _sampleTime ;
      ViewModel   _vm ;
      public DataItem ( int Index, double SampleTime, ViewModel vm )
      {
        _index      = Index ;
        _sampleTime = SampleTime ;
        _vm         = vm ;
      }
      public int Index
      {
        get { return _index ; }
      }
      public double SampleTime
      {
        get { return _sampleTime ; }
      }
      public double Value
      {
        get { return _vm.MyData[_index] ; }
        set { _vm.MyData[_index] = value ; }
      }
    }
