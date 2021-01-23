        private const string SelectedPersonPropertyName = "SelectedPerson";
        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != null)
                {
                    _SelectedPerson.EndEdit();
                }
                if (value != null)
                {
                    value.BeginEdit();
                }
                _SelectedPerson = value;
                RaisePropertyChanged(SelectedPersonPropertyName);
            }
        }
