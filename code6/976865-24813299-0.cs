    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;
    using ADODB;
    using System.Reflection.Emit;
    namespace COMTests.Tests
    {
    [TestClass]
    public class UnitTest1
    {
        private string server;
        private string database;
        private string user;
        private string password;                
        [TestInitialize]
        public void Initialize()
        {
            this.server = "";
            this.database = "";
            this.user = "";
            this.password = "";
        }
        [TestMethod]
        public void TestCreateConectionTheSaneWay()
        {
            ADODB.Connection connection = new ADODB.Connection();
            connection.Provider = "sqloledb";
            connection.ConnectionString = String.Format("Server={0};Database={1};User Id={2};Password={3}",
                this.server, this.database, this.user, this.password);
            connection.ConnectComplete += new ADODB.ConnectionEvents_ConnectCompleteEventHandler(TheConnectionComplete);
            connection.Open();
        }
        [TestMethod]
        public void TestCreateConnectionTheInsaneWay()
        {            
            Type connectionType = Type.GetTypeFromProgID("ADODB.Connection");
            
            EventInfo eventType = connectionType.GetEvent("ConnectComplete");            
            Type[] argumentTypes =
                (from ParameterInfo p in eventType.EventHandlerType.GetMethod("Invoke").GetParameters()
                 select p.ParameterType).ToArray<Type>();
            MethodInfo handler = FabricateAMethod(argumentTypes, "Wow! Should I be happy because it works?", 
                "Ass2", "Type2", "Method2");            
            Delegate d2 = Delegate.CreateDelegate(eventType.EventHandlerType, handler, true);                       
            object o = Activator.CreateInstance(connectionType);
            eventType.AddEventHandler(o, d2);            
            connectionType.GetProperty("Provider").SetValue(o, "sqloledb", null);
            connectionType.GetProperty("ConnectionString").SetValue(o, String.Format("Server={0};Database={1};User Id={2};Password={3}",
                this.server, this.database, this.user, this.password), null);
            connectionType.GetMethod("Open").Invoke(o, new object[] { "", "", "", -1 });            
        }
        [TestMethod]
        public void TestFabricatedMethod()
        {    
            MethodInfo m = FabricateAMethod(new Type[] {}, "Yeap. Works.", "Ass1", "Type1", "Method1");
            m.Invoke(null, new Object[] { });
        }
        private MethodInfo FabricateAMethod(Type[] arguments, string stringToPrint, string assemblyName, 
            string typeName, string methodName)
        {
            AssemblyName aName = new AssemblyName(assemblyName);
            AssemblyBuilder ab =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb =
               ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
            TypeBuilder tb = mb.DefineType(
                typeName,
                TypeAttributes.Public);
            MethodBuilder method = tb.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.Static,
               typeof(void), arguments);
            MethodInfo writeString = typeof(Console).GetMethod("WriteLine",
            new Type[] { typeof(string) });
            ILGenerator il = method.GetILGenerator();
            il.Emit(OpCodes.Ldstr, stringToPrint);
            il.EmitCall(OpCodes.Call, writeString, null);
            il.Emit(OpCodes.Ret);
            return tb.CreateType().GetMethod(methodName);
        }
        public static void TheConnectionComplete(Error pError, ref EventStatusEnum adStatus, Connection pConnection)
        {
            Console.WriteLine("The normal way.");
        }
    }
}
