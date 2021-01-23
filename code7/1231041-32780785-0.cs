    olv.AboutToCreateGroups += delegate(object sender, CreateGroupsEventArgs args) {
        foreach (OLVGroup olvGroup in args.Groups) {
            int totalTime = 0;
            foreach (OLVListItem item in olvGroup.Items) {
                // change this block accordingly
                 MyRowObjectType rowObject = item.RowObject as MyRowObjectType;
                 totalTime += rowObject.MyNumericProperty;
                // change this block accordingly
            }
            olvGroup.Header += String.Format(" (Total time = {0})", totalTime);
        }
    };
