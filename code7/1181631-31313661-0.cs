    Person _Backup = null;
    
        public object Clone()
        {
            return MemberwiseClone();
        }
    
        public void BeginEdit()
        {
            _Backup = Clone() as Person;
            HasChanges = false;
        }
    
    
        public void CancelEdit()
        {
            foreach (var Prop in GetType().GetProperties())
            {
                Prop.SetValue(this, Prop.GetValue(_Backup));
            }
            HasChanges = false;
        }
    
        public void EndEdit()
        {
            _Backup = null;
            HasChanges = false;
        }
