    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Currently it supports up to 255 RPCs
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class RPC : Attribute
    {
        static byte rpcIdCounter = 0;
        //maybe channels
        public byte RpcId { get; private set; }
    
        public RPC()
        {
            RpcId = rpcIdCounter++;
        }
    }
    
    public class NetworkBehaviour
    {
     
        // later network functions
        [RPC] //remote proceure call
        protected void Base()  //example remote call on other computer Move()
        {
        }
    
        [RPC]
        protected virtual void OverridableBase()
        {
        }
    
        protected virtual void OverridableNotRPC()
        {
        }
    }
    
    class ControlCharacter : NetworkBehaviour
    {
        [RPC] //remote proceure call
        void Move()  //example remote call on other computer Move()
        {
    
        }
    
        public void DrawHud() // example this will not do remote call
        {
    
        }
    }
    
    class OtherClass : NetworkBehaviour
    {
        [RPC]
        void Start()
        {
        }
    
        [RPC]
        void Stop()
        {
        }
    
        protected override void OverridableBase()
        {
        }
    
        [RPC]
        protected override void OverridableNotRPC()
        {
        }
    
        void NotRPC()
        {
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            //Console.WriteLine("ControlCharacter ---");
            //var obj = new ControlCharacter();
    
            //foreach(var m in GetRPCMethods(obj)) {
            //    Console.WriteLine(m.ToString());
            //}
    
            //Console.WriteLine("OtherClass ---");
    
            //var other = new OtherClass();
            //foreach(var m in GetRPCMethods(other)) {
            //    Console.WriteLine(m.ToString());
            //}
    
            //Console.WriteLine("NetworkBehaviour ---");
            //var next = (typeof(NetworkBehaviour));
            //foreach(var m in next.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance ).Where(e => e.GetCustomAttribute<RPC>() != null)) {
            //    Console.WriteLine("NetworkBehaviour: " + m.ToString());
            //}
            //Console.WriteLine("");
    
            var assembly = Assembly.GetExecutingAssembly();
            var Types = assembly.GetTypes();
    
            var names = (from type in Types
                         from method in type.GetMethods( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance ).Where(e => e.GetCustomAttribute<RPC>() != null)
                         select type.FullName + ":" + method.Name).ToList();
    
            foreach(var methodNames in names) {
                Console.WriteLine(methodNames);
            }
    
    
        }
    
        //public static IEnumerable<MethodInfo> GetRPCMethods(NetworkBehaviour obj)
        //{
        //    return obj.GetType()
        //        // Remove BindingFlags.DeclaredOnly to include method from base class      
        //              .GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(e => e.GetCustomAttribute<RPC>() != null);
        //}
    }
