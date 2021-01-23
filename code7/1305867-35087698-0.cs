    public void Test()
    {
        var foo = "bla";
		var bar = "blub";
		var msg = Parameters(() => foo).And(() => bar).ToString();
        // msg contains now "foo = bla, bar = blub"
    }
