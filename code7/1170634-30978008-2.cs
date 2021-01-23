            for (int i = 0; i < NewList.Count; i++)
            {
                var record = CurrentList.FirstOrDefault(item => item.Id == NewList[i].Id);
                if (record == null) { CurrentList.Add(NewList[i]); }
                else { record.Id = NewList[i].Id; record.Name = NewList[i].Name; record.Salary = NewList[i].Salary; }
            }
            CurrentList.RemoveAll(item => NewList.FirstOrDefault(item2 => item2.Id == item.Id) == null);
