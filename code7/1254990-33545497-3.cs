    object o = GetMyObject();
    int i;
    System.Drawing.Point p;
    DBSet dbSet;
    bool intCasted = o.TryCast(out i);
    bool pointCasted = o.TryCast(out p);
    bool dbSetCasted = o.TryCast(out dbSet);
