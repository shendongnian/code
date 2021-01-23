        class DataCell
        {
            // constructor requires a value
            public DataCell(string _originalValue)
            {
                OriginalValue = _originalValue;
            } 
            public int Guid; // unique identifier for each cell
            public string OriginalValue; // starting value  
            public string NewValue; // user hasn't entered this yet
            public bool PendingChange = false; // this is the flag you'll check 
            public string DisplayValue // if flagged, show new value, otherwise show original
            {
                get
                {
                    if (PendingChange)
                        return NewValue;
                    else
                        return OriginalValue;
                }
                set
                {
                    NewValue = value;
                    PendingChange = true;
                }
            }
            public void ApplyChange()
            {
                // overwrite the OriginalValue because that's what we write to disk later
                OriginalValue = NewValue;
                PendingChange = false;
            }
            public void UndoChange()
            {
                // turn off the flag to stop showing a new value
                PendingChange = false;
            }
            
        }
         
        static void Main(string[] args)
        {
            // now create a dictionary of these things. 
            Dictionary<string, DataCell> myDataTable = new Dictionary<string, DataCell>();
            
            // take an excel style name like F3
            myDataTable.Add("F3", new DataCell("steve"));
        }
