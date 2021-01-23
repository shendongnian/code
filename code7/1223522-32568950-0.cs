    public static List<TestObject> Tests
    {
        get
        {
            List<TestObject> objects = (List<TestObject>)Session["Tests"];
            if (objects == null)
            {
                objects = new List<TestObject>();
                Session["Tests"] = objects; // Store the new list in the session object!
            }
            return objects;
        }
        set // Do you still need this setter?
        {
            Session["Tests"] = value;
        }
    }
