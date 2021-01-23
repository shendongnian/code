    // This mainclass will create a EventHandleClass which contains an event.
    // This event is binded to the Class1_Example method.
    public class MainClass : IMyClassInfo
    {
        internal void Run()
        {
            EventHandleClass eventHandleClass = new EventHandleClass();
            eventHandleClass.Example += Class1_Example;
            eventHandleClass.CheckEventInfo();
        }
        private void Class1_Example(object sender, EventArgs e)
        {
            Console.WriteLine("Class1_Example Method: ");
        }
        public string WhateverName { get; set; }
    }
---
    // this class holds the event, and when executing `CheckEventInfo()` the 
    // invocationlist is iterated and checkt if the target object is of type IMyClassInfo
    public class EventHandleClass
    {
        public void CheckEventInfo()
        {
            if (Example != null)
                foreach (var item in Example.GetInvocationList())
                {
                    Console.WriteLine("GetInvocationList method:" + item.Method.Name);
                    Console.WriteLine("GetInvocationList class:" + item.Method.DeclaringType.FullName);
                    if (item.Target is IMyClassInfo)
                    {
                        Console.WriteLine("class2.WhateverName: " + ((IMyClassInfo)item.Target).WhateverName);
                    }
                    item.DynamicInvoke(this, EventArgs.Empty);
                }
        }
        public event EventHandler Example;
    }
