    //Defined elsewhere: i1, RotTab[.TabRot]
    //populates tabVal with (t,trot) pairs
    //maxt contains the t value that produced the maximum 
    DataTable tabVal = new DataTable();//move this here, otherwise tabVal will only ever have the last item in it
    //initialize what your columns are
    tabVal.Columns.Add("t", double);
    tabVal.Columns.Add("trot", double);
	
	//These should probably be somewhere else, but for this code I'm putting them here. Magic numbers are bad, mmkay?
	double start = -0.025;
	double end = 0.025;
	double step = 0.001;
	
	//init to the first value, since that's definitely a valid possible max
	double max = RotTab.TabRot(start, i1);
	double maxt = start;
	
	//used for holding what we're looking at.
	double cur;
    for (double t = start; t <= end; t += step) {
		cur = RotTab.TabRot(t, i1);
		if (cur > max) {
			max = cur;
			maxt = t;
		}
        tabVal.Rows.Add(new double[] {t, cur});
    }
	
	
