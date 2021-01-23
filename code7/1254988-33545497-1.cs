    object o = GetMyObject();
    int i;
    System.Drawing.Point p;
    DBSet dbSet;
    bool intCasted = o.TryParse(out i);
    bool pointCasted = o.TryParse(out p);
    bool dbSetCasted = o.TryParse(out dbSet);
