        var tests = new TestList() {
            new Test(){ No = 101 },
            new Test(){ No = 201 },
            new Test(){ No = 300 },
            new Test(){ No = 401 },
            new Test(){ No = 500 },
            new Test(){ No = 601 }
        };
        var newList = new TestList(tests.OrderBy(o => o.No));
