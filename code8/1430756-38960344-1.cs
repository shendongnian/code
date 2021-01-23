    public class TradeItemDatabaseViewModel
    {
        private readonly TradeItem _Model;
        
        public int CountLimit
        {
            get { return _Model.CountLimit; }
            set(int value) 
            {
                if(Equals(_Model.CountLimit, value) == true) return;
                this.SaveCountLimit(value);
                _Model.CountLimit = value;
                this.RaisePropertyChanged(nameOf(this.CountLimit));
            }           
        }
        private void SaveCountLimit(int value)
        {
            var repository = new ItemsRepository();
            var dto_item = repository.GetById(item.ClassId, item.IntanceId);
            dto_item.CountLimit = item.CountLimint;
            repository.Update(dto_item);
        }
    }
