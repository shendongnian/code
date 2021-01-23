    using System.Collections.Generic;
    public class newClass
    {
    public string name;
    public int? num;
    public newClass(int index)
    {
        switch (index)
        {
            case 1:
                num = 20;
                name = "returns true";
                break;
            case 2:
                // no num here
                name = "returns false";
                break;
            default:
                break;
        }
    }
    }
    public class otherClass
    {
    newClass foo = new newClass(1);
    newClass bar = new newClass(2);
    List<newClass> newClassList = new List<newClass>();
    public otherClass()
    {
        newClassList.Add(foo);
        newClassList.Add(bar);
        foreach (newClass nc in newClassList)
        {
            if (nc.num != null)
            {
                print("True");
            }
            print("False");
        }
    }
    private void print(string msg)
    {
        throw new System.NotImplementedException();
    }
    }
