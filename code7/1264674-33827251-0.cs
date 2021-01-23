    [Test]
    [Category("Category1")
    private void DoSomethingForCat1()
    {
        TestSomeStuff("category1");
    }
    [Test]
    [Category("Category2")
    private void DoSomethingForCat2()
    {
        TestSomeStuff("category2");
    }
    private void TestSomeStuff(string category)
    {
        if(category == "Category1"){
            (...)
        }
        else if(category == "Category2"){
            (...)
        }
    }
