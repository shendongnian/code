    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace DelegateToInstance {
      class Program {
        static void Main(string[] args) {
          var obj = new Caller();
          obj.button_click();
          Console.ReadKey();
        }
      }
      class Caller
      {
        private ClassA theA;
        public Caller()
        {
          theA = new ClassA();
        }
    
        public void button_click()
        {
          theA.Execute(false);
        }
        public void button2_click()
        {
          theA.Execute( true );
        }
      }
      interface IClassA
      {
        void ActionMinus();
      }
      class ClassA
      {
        public int VariableA = 0;
        public void Execute( bool wait )
        {
          ClassB instanceB = new ClassB(this);
          Thread thread = new Thread( instanceB.Action ) // error in here
          { 
            Name = "Executor",
            Priority = ThreadPriority.Highest
          };
    
          thread.Start();
          if( wait )
            thread.Join();
        }
        public void ActionMinus()
        {
          //someAction1
          VariableA -= 2;
          //someAction2
        }
      }
    
      class ClassB
      {
        private readonly ClassA instanceA;
        public ClassB( ClassA instance )
        {
          instanceA = instance;
        }
        public void Action()
        {
          //some other action3
          instanceA.VariableA += 5;
          //some other action4
          instanceA.ActionMinus();
          //some other action5
        }
      }
    }
