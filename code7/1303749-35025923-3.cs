    ***** except.Test.ExpectedException
    ***** except.Test.ExpectedNotSystemException
    ***** except.Test.ExpectedNotTypeOfSystemException
    ***** except.Test.NotExpectedException
    
    Tests run: 4, Failures: 1, Not run: 0, Time: 0.106 seconds
    
    Test Case Failures:
    1) except.Test.NotExpectedException : System.Exception : Stackoverflow
    at except.Test.NotExpectedException () [0x00006] in /Users/sushi/code/XamTests/except/except/Test.cs:33
    at (wrapper managed-to-native) System.Reflection.MonoMethod:InternalInvoke (System.Reflection.MonoMethod,object,object[],System.Exception&)
    at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00038] in /private/tmp/source-mono-mac-4.2.0-branch-c6sr1/bockbuild-mono-4.2.0-branch/profiles/mono-mac-xamarin/build-root/mono-4.2.2/mcs/class/corlib/System.Reflection/MonoMethod.cs:295
