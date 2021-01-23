        public ObservableCollection<SlotType> slotTypes { get; set; }
        public Slot slot
        {
            get { return _slot; }
            set
            {
                _slot = value;
                OnPropertyChanged();
            }
        }
        public int SelectedSlotType
        {
            get { return _selectedSlotType; }
            set
            {
                _selectedSlotType = value;
                OnPropertyChanged();
                UpdateSlot(SelectedSlotType);
            }
        }
        private void UpdateSlot(int selectedSlotType)
        {
            slot.SlotType = selectedSlotType;
        }
