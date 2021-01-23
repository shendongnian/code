      var _client = new MongoClient(@"....");
      var _database = _client.GetDatabase("...");
      var _students =  _database.GetCollection<Student>("students");
      var filter = Builders<Student>.Filter;
      var studentIdAndCourseIdFilter = filter.And(
        filter.Eq(x => x.Id, "234dssfcv456"),
        filter.ElemMatch(x => x.Courses, c => c.Id == "1234") );
       // find student with id and course id
       var student = _students.Find(studentIdAndCourseIdFilter).SingleOrDefault();
      // update with positional operator
      var update = Builders<Student>.Update;      
      var courseLevelSetter = update.Set("Courses.$.Level", "Updated Level");
      _students.UpdateOne(studentIdAndCourseIdFilter, courseLevelSetter);
