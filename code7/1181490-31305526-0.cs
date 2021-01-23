    protected override void OnListItemClick(ListView l, View v, int position, long id)
    {
        var actType = Type.GetType("part of full path" + items[position] + "Activity")
        var intentPlace = new Intent(this, typeof(actType));
        StartActivity(intentPlace);
    }
