    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.CSharp.RuntimeBinder; // Requires reference to Microsoft.CSharp
    
    public class ImplicitTest
    {
        public double Val { get; set; }
    
        public ImplicitTest(double val)
        {
            this.Val = val;
        }
    
        public static implicit operator int(ImplicitTest d)
        {
            return (int)d.Val;
        }
    }
    
    public class TestClass
    {
        public int Val { get; set; }
    
        public TestClass(int val)
        {
            this.Val = val;
        }
    
        public TestClass(int val1, int val2)
        {
            this.Val = val1 + val2;
        }
    }
    
    public static class DynamicFactory
    {
        private static readonly CallSiteBinder callsiteBinder = Binder.InvokeConstructor(
            CSharpBinderFlags.None,
            typeof(DynamicFactory),
            // It is OK to have too many arguments :-)
            new CSharpArgumentInfo[] 
            {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.IsStaticType | CSharpArgumentInfoFlags.UseCompileTimeType, null), // 0 parameters
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), // 1 parameter
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), // 2 parameters
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), 
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), 
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), 
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), // 13 parameters
            });
    
        public static object Create(string typeName, params object[] args)
        {
            return Create(Type.GetType(typeName), args);
        }
    
        public static object Create(Type type, params object[] args)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
    
            if (args == null)
            {
                args = new object[0];
            }
    
            switch (args.Length)
            {
                case 0:
                    {
                        var callSite = CallSite<Func<CallSite, Type, object>>.Create(callsiteBinder);
                        object obj = callSite.Target(callSite, type);
                        return obj;
                    }
    
                case 1:
                    {
                        var callSite = CallSite<Func<CallSite, Type, object, object>>.Create(callsiteBinder);
                        object obj = callSite.Target(callSite, type, args[0]);
                        return obj;
                    }
    
                case 2:
                    {
                        var callSite = CallSite<Func<CallSite, Type, object, object, object>>.Create(callsiteBinder);
                        object obj = callSite.Target(callSite, type, args[0], args[1]);
                        return obj;
                    }
    
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    throw new NotImplementedException("You have to implement them like the code I wrote");
    
                default:
                    throw new ArgumentException("Too many parameters");
            }
        }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		try
    		{
    		    TestClass tc1 = (TestClass)DynamicFactory.Create("TestClass", new ImplicitTest(15.5));
    		    TestClass tc2 = (TestClass)DynamicFactory.Create("TestClass", 5);
    	        TestClass tc3 = (TestClass)DynamicFactory.Create("TestClass", new ImplicitTest(15.5), new ImplicitTest(10.0));
    		
    		    Console.WriteLine(tc1.Val);
    		    Console.WriteLine(tc2.Val);
    	        Console.WriteLine(tc3.Val);
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex);
    		}
    	}
    }
