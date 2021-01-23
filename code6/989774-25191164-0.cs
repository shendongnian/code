    class Foo {
        public void SomeMethod() {
            ExecuteAction();
            ExecuteAction();
        }
        public void ExecuteAction() {
            //
        }
    }
    // --- Read the IL ---
    var mInfo = typeof(Foo).GetMethod("SomeMethod");
    var token = typeof(Foo).GetMethod("ExecuteAction").MetadataToken;
    
    var methodBody = mInfo.GetMethodBody();
    var rawIL = methodBody.GetILAsByteArray();
    
    int counter = 0;
    var reader = new ILReader(rawIL);
    while(reader.Read(mInfo)) {
        if(reader.OpCode == OpCodes.Call && object.Equals(reader.MetadataToken, token)) {
            System.Console.WriteLine("Method \"{0}\" call detected", reader.Operand);
            counter++;
        }
    }
    System.Console.WriteLine("Total: {0}", counter);
