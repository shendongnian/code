    var nameArr = name.Split(' ');
    if (nameArr.length > 3)
    {
        var fName = nameArr [0];
        var lname = nameArr[nameArr.length-1];
        string middlename;
        for (int i = 1; i < nameArr.length - 1; i++)
        {
            middlename += nameArr[i];
            //probably a more elegant way of joining the names
        }
    }
