    var input = new object();
    var input2 = new object();
      var dict = new Dictionary<int, course<T1, T2>>
      {
        {1, new course<T1, T2> {CourseID =(T1)Convert.ChangeType(input, typeof(T1)),
                                PersonID = (T2)Convert.ChangeType(input2, typeof(T2))}}
      };
