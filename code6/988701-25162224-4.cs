    // create new class
    var originalClass = new CFingerPrint();
    // fill some data
    originalClass.WanIP = "test1";
    originalClass.MacAddress= "test2";
    
    // serialize to json string
    var classSerialized = originalClass.getClassEncrypted();
    
    // create new class from string only
    var newClass = new CFingerPrint().getClassDecrypted(classSerialized);
    Console.WriteLine(newClass.WanIP); // output "test1"
    Console.WriteLine(newClass.MacAddress); // output "test2"
