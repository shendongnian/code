    private void SetFloorsToDropDown()
    {
        List<DropDownModel> floorList = new List<DropDownModel>();
    
        floorList.Add(new DropDownModel()
        {
            Id = 0,
            Name = "SELECT FLOOR",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 1,
            Name = "1st Floor",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 2,
            Name = "2nd Floor",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 3,
            Name = "3rd Floor",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 4,
            Name = "4th Floor",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 5,
            Name = "5th Floor",
        });
    
        floorList.Add(new DropDownModel()
        {
            Id = 6,
            Name = "6th Floor",
        });
    
        Floor.DataSource = floorList;
        Floor.DisplayMember = "Name";
        Floor.ValueMember = "Id";
    }
