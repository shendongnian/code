    public async Task AddData(Data data)
        {
            var id = data.ID;
            Group newGroup = new Group(id);
            bool checkIfExists = false;
            foreach (Group group in _groups)
            {
                if (group.ID == newGroup.ID)
                {
                    checkIfExists = true;
                    break;
                }               
            }
            if (checkIfExists)
            {
                foreach (Group group in _groups)
                {
                    if (group.ID == id)
                    {
                        group.DataGroup.Add(data);
                    }
                }       
            }
            else
            {
                newGroup.DataGroup.Add(data);
                _groups.Add(newGroup);
            }
                           
            await saveDataAsync();               
        }
