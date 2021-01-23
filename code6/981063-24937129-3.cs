    internal class DrawDown
    {
        int _n;
        int _startIndex, _endIndex, _troughIndex;
        public int Count { get; set; }
        LinkedList<double> _values;
        public double Peak { get; set; }
        public double Trough { get; set; }
        public bool SkipMoveBackDoubleCalc { get; set; }
        public int PeakIndex
        {
            get
            {
                return _startIndex;
            }
        }
        public int TroughIndex
        {
            get
            {
                return _troughIndex;
            }
        }
        //peak to trough return
        public double DrawDownAmount
        {
            get
            {
                return Peak - Trough;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">max window for drawdown period</param>
        /// <param name="peak">drawdown peak i.e. start value</param>
        public DrawDown(int n, double peak)
        {
            _n = n - 1;
            _startIndex = _n;
            _endIndex = _n;
            _troughIndex = _n;
            Count = 1;
            _values = new LinkedList<double>();
            _values.AddLast(peak);
            Peak = peak;
            Trough = peak;
        }
        /// <summary>
        /// adds a new observation on the drawdown curve
        /// </summary>
        /// <param name="newValue"></param>
        public void Add(double newValue)
        {
            //push the start of this drawdown backwards
            //_startIndex--;
            //the end of the drawdown is the current period end
            _endIndex = _n;
            //the total periods increases with a new observation
            Count++;
            //track what all point values are in the drawdown curve
            _values.AddLast(newValue);
            //update if we have a new trough
            if (newValue < Trough)
            {
                Trough = newValue;
                _troughIndex = _endIndex;
            }
        }
        /// <summary>
        /// Shift this Drawdown backwards in the observation window
        /// </summary>
        /// <param name="trackingNewPeak">whether we are already tracking a new peak or not</param>
        /// <returns>a new drawdown to track if a new peak becomes active</returns>
        public DrawDown MoveBack(bool trackingNewPeak, bool recomputeWindow = true)
        {
            if (!SkipMoveBackDoubleCalc)
            {
                _startIndex--;
                _endIndex--;
                _troughIndex--;
                if (recomputeWindow)
                    return RecomputeDrawdownToWindowSize(trackingNewPeak);
            }
            else
                SkipMoveBackDoubleCalc = false;
            return null;
        }
        private DrawDown RecomputeDrawdownToWindowSize(bool trackingNewPeak)
        {
            //the start of this drawdown has fallen out of the start of our observation window, so we have to recalculate the peak of the drawdown
            if (_startIndex < 0)
            {
                Peak = double.NegativeInfinity;
                _values.RemoveFirst();
                Count--;
                //there is the possibility now that there is a higher peak, within the current drawdown curve, than our first observation
                //when we find it, remove all data points prior to this point
                //the new peak must be before the current known trough point
                int iObservation = 0, iNewPeak = 0, iNewTrough = _troughIndex, iTmpNewPeak = 0, iTempTrough = 0;
                double newDrawDown = 0, tmpPeak = 0, tmpTrough = double.NegativeInfinity;
                DrawDown newDrawDownObj = null;
                foreach (var pointOnDrawDown in _values)
                {
                    if (iObservation < _troughIndex)
                    {
                        if (pointOnDrawDown > Peak)
                        {
                            iNewPeak = iObservation;
                            Peak = pointOnDrawDown;
                        }
                    }
                    else if (iObservation == _troughIndex)
                    {
                        newDrawDown = Peak - Trough;
                        tmpPeak = Peak;
                    }
                    else
                    {
                        //now continue on through the remaining points, to determine if there is a nested-drawdown, that is now larger than the newDrawDown
                        //e.g. higher peak beyond _troughIndex, with higher trough than that at _troughIndex, but where new peak minus new trough is > newDrawDown
                        if (pointOnDrawDown > tmpPeak)
                        {
                            tmpPeak = pointOnDrawDown;
                            tmpTrough = tmpPeak;
                            iTmpNewPeak = iObservation;
                            //we need a new drawdown object, as we have a new higher peak
                            if (!trackingNewPeak) 
                                newDrawDownObj = new DrawDown(_n + 1, tmpPeak);
                        }
                        else
                        {
                            if (!trackingNewPeak && newDrawDownObj != null)
                            {
                                newDrawDownObj.MoveBack(true, false); //recomputeWindow is irrelevant for this as it will never fall before period 0 in this usage scenario
                                newDrawDownObj.Add(pointOnDrawDown);  //keep tracking this new drawdown peak
                            }
                                
                            if (pointOnDrawDown < tmpTrough)
                            {
                                tmpTrough = pointOnDrawDown;
                                iTempTrough = iObservation;
                                var tmpDrawDown = tmpPeak - tmpTrough;
                                if (tmpDrawDown > newDrawDown)
                                {
                                    newDrawDown = tmpDrawDown;
                                    iNewPeak = iTmpNewPeak;
                                    iNewTrough = iTempTrough;
                                    Peak = tmpPeak;
                                    Trough = tmpTrough;
                                }
                            }
                        }
                    }
                    iObservation++;
                }
                _startIndex = iNewPeak; //our drawdown now starts from here in our observation window
                _troughIndex = iNewTrough;
                for (int i = 0; i < _startIndex; i++)
                {
                    _values.RemoveFirst(); //get rid of the data points prior to this new drawdown peak
                    Count--;
                }
                return newDrawDownObj;
            }
            return null;
        }
    }
    public class RunningDrawDown
    {
        int _n;
        List<DrawDown> _drawdownObjs;
        DrawDown _currentDrawDown;
        DrawDown _maxDrawDownObj;
        /// <summary>
        /// The Peak of the MaxDrawDown
        /// </summary>
        public double DrawDownPeak
        {
            get
            {
                if (_maxDrawDownObj == null) return double.NegativeInfinity;
                return _maxDrawDownObj.Peak;
            }
        }
        /// <summary>
        /// The Trough of the Max DrawDown
        /// </summary>
        public double DrawDownTrough
        {
            get
            {
                if (_maxDrawDownObj == null) return double.PositiveInfinity;
                return _maxDrawDownObj.Trough;
            }
        }
        /// <summary>
        /// The Size of the DrawDown - Peak to Trough
        /// </summary>
        public double DrawDown
        {
            get
            {
                if (_maxDrawDownObj == null) return 0;
                return _maxDrawDownObj.DrawDownAmount;
            }
        }
        /// <summary>
        /// The Index into the Window that the Peak of the DrawDown is seen
        /// </summary>
        public int PeakIndex
        {
            get
            {
                if (_maxDrawDownObj == null) return 0;
                return _maxDrawDownObj.PeakIndex;
            }
        }
        /// <summary>
        /// The Index into the Window that the Trough of the DrawDown is seen
        /// </summary>
        public int TroughIndex
        {
            get
            {
                if (_maxDrawDownObj == null) return 0;
                return _maxDrawDownObj.TroughIndex;
            }
        }
        /// <summary>
        /// Creates a running window for the calculation of MaxDrawDown within the window
        /// </summary>
        /// <param name="n">the number of periods within the window</param>
        public RunningDrawDown(int n)
        {
            _n = n;
            _currentDrawDown = null;
            _drawdownObjs = new List<DrawDown>();
        }
        /// <summary>
        /// The new value to add onto the end of the current window (the first value will drop off)
        /// </summary>
        /// <param name="newValue">the new point on the curve</param>
        public void Calculate(double newValue)
        {
            if (double.IsNaN(newValue)) return;
            if (_currentDrawDown == null)
            {
                var drawDown = new DrawDown(_n, newValue);
                _currentDrawDown = drawDown;
                _maxDrawDownObj = drawDown;
            }
            else
            {
                //shift current drawdown back one. and if the first observation falling outside the window means we encounter a new peak after the current trough, we start tracking a new drawdown
                var drawDownFromNewPeak = _currentDrawDown.MoveBack(false);
                
                //this is a special case, where a new lower peak (now the highest) is created due to the drop of of the pre-existing highest peak, and we are not yet tracking a new peak
                if (drawDownFromNewPeak != null)
                {
                    _drawdownObjs.Add(_currentDrawDown); //record this drawdown into our running drawdowns list)
                    _currentDrawDown.SkipMoveBackDoubleCalc = true; //MoveBack() is calculated again below in _drawdownObjs collection, so we make sure that is skipped this first time
                    _currentDrawDown = drawDownFromNewPeak;
                    _currentDrawDown.MoveBack(true);
                }
                
                if (newValue > _currentDrawDown.Peak)
                {
                    //we need a new drawdown object, as we have a new higher peak
                    var drawDown = new DrawDown(_n, newValue);
                    //do we have an existing drawdown object, and does it have more than 1 observation
                    if (_currentDrawDown.Count > 1)
                    {
                        _drawdownObjs.Add(_currentDrawDown); //record this drawdown into our running drawdowns list)
                        _currentDrawDown.SkipMoveBackDoubleCalc = true; //MoveBack() is calculated again below in _drawdownObjs collection, so we make sure that is skipped this first time
                    }
                    _currentDrawDown = drawDown;
                }
                else
                {
                    //add the new observation to the current drawdown
                    _currentDrawDown.Add(newValue);
                }
            }
                
            //does our new drawdown surpass any of the previous drawdowns?
            //if so, we can drop the old drawdowns, as for the remainer of the old drawdowns lives in our lookup window, they will be smaller than the new one
            var newDrawDown = _currentDrawDown.DrawDownAmount;
            _maxDrawDownObj = _currentDrawDown;
            var maxDrawDown = newDrawDown;
            var keepDrawDownsList = new List<DrawDown>();
            foreach (var drawDownObj in _drawdownObjs)
            {
                drawDownObj.MoveBack(true);
                if (drawDownObj.DrawDownAmount > newDrawDown)
                {
                    keepDrawDownsList.Add(drawDownObj);
                }
                    
                //also calculate our max drawdown here
                if (drawDownObj.DrawDownAmount > maxDrawDown)
                {
                    maxDrawDown = drawDownObj.DrawDownAmount;
                    _maxDrawDownObj = drawDownObj;
                }
                    
            }
            _drawdownObjs = keepDrawDownsList;
             
        }
    }
