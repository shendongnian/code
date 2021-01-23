        bool isElephant = vendor == "elephant";
        bool isPiglet = vendor == "piglet";
        bool isOrange = vendor == "orange";
        ...
        if (isElephant)
        {
            ...
        }
        if (isPiglet)
        {
            ...
        }
        ...
        mygv.Columns[10].Visible = isElephant;
        mygv.Columns[11].Visible = isElephant;
        mygv.Columns[14].Visible = isPiglet;
        mygv.Columns[15].Visible = isPiglet;
        mygv.Columns[20].Visible = isElephant || isOrange;
        mygv.Columns[21].Visible = isPiglet || isOrange;
        ...
