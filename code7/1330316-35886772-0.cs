    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.CSharp.RuntimeBinder;
    
    public class ImplicitTest
    {
        public double Val { get; set; }
    
        public ImplicitTest(double Val)
        {
            this.Val = Val;
        }
    
        public static implicit operator int(ImplicitTest d)
        {
            return (int)d.Val;
        }
    }
    
    public class TestClass
    {
        public int Val { get; set; }
    
        public TestClass(ImplicitTest Val)
        {
            this.Val = (int)Val.Val;
        }
    
        public TestClass(int Val)
        {
            this.Val = Val;
        }
    }
    
    public static class DynamicFactory
    {
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
    
            var callsiteBinder = Binder.InvokeConstructor(
                CSharpBinderFlags.None,
                typeof(DynamicFactory),
                new CSharpArgumentInfo[] { 
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.IsStaticType | CSharpArgumentInfoFlags.UseCompileTimeType, null), 
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) 
            });
    
            Delegate constructorDelegate = null;
            CallSite callSite = null;
    
            switch (args.Length)
            {
                case 0:
                    {
                        var callSite2 = CallSite<Func<CallSite, Type, object>>.Create(callsiteBinder);
                        callSite = callSite2;
                        constructorDelegate = callSite2.Target;
                        break;
                    }
    
                case 1:
                    {
                        var callSite2 = CallSite<Func<CallSite, Type, object, object>>.Create(callsiteBinder);
                        callSite = callSite2;
                        constructorDelegate = callSite2.Target;
                        break;
                    }
    
                case 2:
                    {
                        var callSite2 = CallSite<Func<CallSite, Type, object, object, object>>.Create(callsiteBinder);
                        callSite = callSite2;
                        constructorDelegate = callSite2.Target;
                        break;
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
    
            var args2 = new object[args.Length + 2];
            args2[0] = callSite;
            args2[1] = type;
            Array.Copy(args, 0, args2, 2, args.Length);
    
            object obj = constructorDelegate.DynamicInvoke(args2);
            return obj;
        }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    	    TestClass tc1 = (TestClass)DynamicFactory.Create("TestClass", new ImplicitTest(15.5));
    	    TestClass tc2 = (TestClass)DynamicFactory.Create("TestClass", 5);
    	
    	    Console.WriteLine(tc1.Val);
    	    Console.WriteLine(tc2.Val);
    	}
    }
