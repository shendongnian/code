       for(int i = 0; i < NewList.Count; i++)
        {
            var record = CurrentList.FirstOrDefault(item => item.Id == NewList[i].Id);
            If(record == null) { CurrentList.Add(NewList[i]); }
            else { record = NewList[i]; }        
        }       
    
        CurrentList.RemoveAll(item => NewList.FirstOrDefault(item2 => item2.Id == item.Id) == null);
