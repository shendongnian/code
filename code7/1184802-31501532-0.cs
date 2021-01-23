    int token = moduleBuilder.GetMethodToken(typeof(Class1).GetMethod("Method1")).Token;
    SignatureHelper sigHelper = Exposed.From(typeof(SignatureHelper))
        .GetMethodSpecSigHelper(moduleBuilder, new Type[] { typeParameter });
    var getSignatureParameters = new object[] { 0 };
    byte[] bytes = (byte[])typeof(SignatureHelper).GetMethod(
        "InternalGetSignature", BindingFlags.NonPublic | BindingFlags.Instance)
        .Invoke(sigHelper, getSignatureParameters);
    int length = (int)getSignatureParameters[0];
    var runtimeModule = Exposed.From(moduleBuilder).GetNativeHandle();
    token = (int)typeof(TypeBuilder)
        .GetMethod("DefineMethodSpec", BindingFlags.NonPublic | BindingFlags.Static)
        .Invoke(null, new object[] { runtimeModule, token, bytes, length });
