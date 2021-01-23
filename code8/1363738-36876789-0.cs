        public class ModelNumber
    {
        public decimal N1 { get; set; }
        public decimal N2 { get; set; }
        public decimal Result { get; set; }
    }
    public class ViewModelNumber : NotifyPropertyChanged, IDataErrorInfo
    {
        protected ModelNumber __dataModel = null;
        #region ---constructor---
        public ViewModelNumber()
        {
            // model init
            this.__dataModel = new ModelNumber();
        }
        #endregion
        #region ---accessoren model basis---
        public decimal N1
        {
            get
            {
                return this.__dataModel.N1;
            }
            set
            {
                if (this.__dataModel.N1 != value)
                {
                    this.__dataModel.N1 = value;
                    this.OnPropertyChanged("N1");
                }
            }
        }
        public decimal N2
        {
            get
            {
                return this.__dataModel.N2;
            }
            set
            {
                if (this.__dataModel.N2 != value)
                {
                    this.__dataModel.N2 = value;
                    this.OnPropertyChanged("N1");
                }
            }
        }
        public decimal Result
        {
            get
            {
                return this.__dataModel.Result;
            }
            set
            {
                if (this.__dataModel.Result != value)
                {
                    this.__dataModel.Result = value;
                    this.OnPropertyChanged("N1");
                }
            }
        }
        #endregion
        #region ---validation---
        /// <summary>Gets an error message indicating what is wrong with this object.</summary>
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>Gets the error message for the property with the given name.</summary>
        public string this[string _columnName]
        {
            get
            {
                try
                {
                    if (_columnName != null)
                    {
                        switch (_columnName)
                        {
                            default:
                                break;
                        }
                    }
                    return (null);
                }
                catch (Exception _except)
                {
                    // mlog
                    Log.Exception(this.GetType().FullName, MethodBase.GetCurrentMethod().Name, _except);
                    return (null);
                }
            }
        }
        #endregion
    }
    ObservableCollection<ViewModelNumber> lstOperations;
