    public class Values
    {
       public int value_1 { set; get; }
       public int value_2 { set; get; }
    }
    Session["values"] = new Values() { value_1 = 1, value_2 = 2 };
