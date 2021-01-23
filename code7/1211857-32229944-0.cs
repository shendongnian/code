    var tmp0 = new MyClass();
    var tmp1 = new List<MyOtherClass>();
    var tmp2 = new MyOtherClass();
    var tmp3 = new DateTimeValue();
    tmp3.DateTime = new DateTime(2015, 8, 23);
    // Note the assignment to Start here
    tmp2.Start = tmp3;
    // No assignment to End -
    // it's calling the End "getter" and then the DateTime "setter" on the result
    tmp2.End.DateTime = new DateTime(2015, 8, 23);
    tmp1.Add(tmp2);
    tmp0.MyValues = tmp1;
    var target = tmp0;
