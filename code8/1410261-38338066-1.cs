    //Calculation1.cs
    partial class ClassRoom
    {
    private int boycount;   //field
    public ClassRoom()     //default constructor
    {
        boycount = 30;
    }
    }
    //Calculation2.cs
    partial class ClassRoom
    {
    public ClassRoom(int bcount)     //overloaded constructor
    {
        boycount = bcount;
    }
    public double Avg()     //method
    {
        //statements goes here
    }
    }
