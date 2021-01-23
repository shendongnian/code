    ArrayList tasks = new ArrayList();
    
        foreach (DataGridViewRow row in tblProduct.Rows)
        
            {
        
                Task newTask = new Task(() =>
                {
                    DataGridViewRow rowCopy = row;
                    checkRow(rowCopy);
                });
            
                tasks.Add(newTask);
                newTask.Start();   
            }
