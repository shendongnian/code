    class EventHandleClass
    {
        public void CheckEventInfo()
        {
            if (Example != null)
                foreach (var item in Example.GetInvocationList())
                {
                    Console.WriteLine("GetInvocationList method:" + item.Method.Name);
                    Console.WriteLine("GetInvocationList class:" + item.Method.DeclaringType.FullName);
                    if (item.Target is MainClass)
                    {
                        Console.WriteLine("class2.WhateverName: " + ((MainClass)item.Target).WhateverName);
                    }
                    item.DynamicInvoke(this, EventArgs.Empty);
                }
        }
        public event EventHandler Example;
    }
