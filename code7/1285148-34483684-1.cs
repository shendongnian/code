    //temporary dictionary used only while converting
    var Groups = new Dictionary<int,Group>();
    //final variable where the result will be in
    var hierarchy = new List<Group>();
    //creating groups
    foreach (var item in data.Where(x=> x.groupFlag==1)) {
        var grp = new Group() {
            Key = item.ID,
            Name = item.Name,
            Entries = new List<Entry>(),
            SubGroups = new List<Group>()
        };
        //store reference for later use
        Groups[item.ID] = grp;
        if (item.fatherID == null) {
            //store it in main list
            hierarchy.Add(grp);
        } else {
            //store it in its parent
            Groups[(int)item.fatherID].SubGroups.Add(grp);
        }
    }
    //fill entries
    foreach(var item in data.Where(x=> x.groupFlag == 0)) {
        Groups[(int)item.fatherID].Entries.Add(new Entry() {
            Key = item.ID,
            Name = item.Name
        });
    }
