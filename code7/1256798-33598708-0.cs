    class Counter
    {
      public delegate void IndexValueChangedEventHandler(object sender, IndexValueChangedEventArgs e);
      public event IndexValueChangedEventHandler IndexValueChanged;
      int _maxNumber;
      int _index;
	  Control _parent;
    
      public Counter(Control parent, int maxNumber)
      {
        _maxNumber = maxNumber;
	    _parent = parent;
      }
      public async void StartCountAsync()
      {
        await Task.Run(() =>
        {
            for (int i = 0; i < _maxNumber; i++)
            {
                _index = i;
	            if (IndexValueChanged != null)
	            {
		            if (_parent == null || !_parent.InvokeRequired)
			            IndexValueChanged(this, new IndexValueChangedEventArgs(_index));
		            else
                        // use BeginInvoke
			            _parent.BeginInvoke(IndexValueChanged, this, new IndexValueChangedEventArgs(_index));
	            }
	            Thread.Sleep(100);
            }
        });
      }
    }
