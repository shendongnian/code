        private void InitDataContext()
        {
            DataContext = new SlotWithTypes
            {
                slot = new Slot(),
                slotTypes = new ObservableCollection<SlotType>(new List<SlotType>
                {
                    new SlotType
                    {
                        SlotTypeDesc = "Bla Bla 1",
                        SlotTypeID = 1,
                    },
                    new SlotType
                    {
                        SlotTypeDesc = "Bla Bla 2",
                        SlotTypeID = 2,
                    }
                })
            };
        }
