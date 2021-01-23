	private float _ordinaryMps;
	public float OrdinaryMps
		{
		set {
			_ordinaryMps = value;
			foreach(BaseFrite e in all)
				e.mpsNow = _ordinaryMps * widthSpeedFactor;
			}
		get { return _ordinaryMps; }
		}
     
	private float _mps;
	public float Mps
		{
		set {
			_mps = value;
			for (int i=0; i<kParts; ++i)
				parts[i].mps = Mps;
			}
		get { return _mps; }
		}
      
	public int Count
		{
		get { return prepped != null ? prepped.Count : 0; }
		}
	private int _hearts;
	public int Hearts
		{
		set {
			_hearts = value;
			controls.HeartNumber(_hearts);
			}
		get { return _hearts; }
		}
	
	private int _megabombs;
	public int Megabombs
		{
		set {
			_megabombs = value;
			controls.MegabombNumber(_megabombs);
			}
		get { return _megabombs; }
		}
