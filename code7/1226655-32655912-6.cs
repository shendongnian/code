    public static void SetRValue(string product_id, r_type r)
    {
        // you can use it explicitely
        var t = r.Value;
        // or sometimes even better, implicitely
        // thanks to implicit conversion operator
        double g = r;
    }
