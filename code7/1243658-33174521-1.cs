    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        // Create an array of the department numbers as strings
        string[] Edpt = Row.DeptNo.Split(new char[] { ',' });
        // no longer needed
        int i = 0;
        // foreach avoids off by one errors
        foreach (var item in Edpt)
        {
            Output0Buffer.AddRow();
            Output0Buffer.ID = Row.ID;
            Output0Buffer.Name = Row.Name;
            Output0Buffer.Location = Row.Location;
            // use the iterator directly
            Output0Buffer.DeptNo = Int32.Parse(item);
        }
    }
