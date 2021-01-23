     ObservableCollection<Activity> _activitiesList = new ObservableCollection<Activity>();
    
    **while (reader.Read())
                {
                    ***_act = new Activity();***
                    _act.Name = reader.GetString(reader.GetOrdinal("Activity"));
                   ....
                   ....
                 }**
