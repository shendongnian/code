        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (_isBusyUpdating) return;
            lock (obj)
            {
                _isBusyUpdating = true;
                // Get new data values and update the list
                try
                {
                    ContactIdNames = new ConcurrentDictionary<int, string>();
                    using (var db = new DBEntities())
                    {
                        foreach (var item in db.ContactIDs.Select(x => new { x.Qualifier, x.AlarmCode, x.Description }).AsEnumerable())
                        {
                            int key = (item.Qualifier * 1000) + item.AlarmCode;
                            _contactIdNames.TryAdd(key, item.Description);
                        }
                    }                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error occurred in update ContactId db store", e);        
                    _contactIdNames = _contactIdNamesOld;            
                }
                finally 
                {                   
                    _isBusyUpdating = false;
                }
            }
        }
