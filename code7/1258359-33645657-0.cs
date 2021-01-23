    public class SPCModelDTOViewModel: INotifyPropertyChanged
    {
        private SPCModelDTO _Model;
        public double? USL 
        { 
            get { return _Model.USL;} 
            set 
            {
                if(value.HasValue == false)
                    _Model.USL = 3.0;
                else
                    _Model.USL = value;
                this.RaisePropertyChangedEvent();
            } 
        }
        //Other model's properties
    }
