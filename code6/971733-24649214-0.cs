      class Layout
       {
    int mode1 { get; set; }
    int geom2 { get; set; }
    int type3 { get; set; }
    int spacing4 { get; set; }
    int fluid5 { get; set; }
    int spec6 { get; set; }
    public int this[int number]
    {
        get
        {
            if (number == 1)
                return mode1;
            else if (number == 2)
                return geom2;
            else if (number == 3)
                return type3;
            else if (number == 4)
                return spacing4;
            else if (number == 5)
                return fluid5;
            else if (number == 6)
                return spec6;
            else
                return -1;
        }
        set
        {
            if (number == 1)
                mode1 = value;
            else if (number == 2)
                geom2 = value;
            else if (number == 3)
                type3 = value;
            else if (number == 4)
                spacing4 = value;
            else if (number == 5)
                fluid5 = value;
            else if (number == 6)
                spec6 = value;
        }
    }
