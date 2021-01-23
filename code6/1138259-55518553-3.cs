    var AllDbResults_2mRec = new List<MyByteClass>();
    foreach (var fields in DbRowProvider)
       AllDbResults_2mRec.Add(
       new MyClass {
            Country = byteArrayInterningObject.Intern(fields[0].ASCII_bytes() ),
            Province = byteArrayInterningObject.Intern(fields[1].ASCII_bytes() ),
            City = byteArrayInterningObject.Intern(fields[2].ASCII_bytes() ),
          } );
