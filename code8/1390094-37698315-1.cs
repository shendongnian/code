           List<TestObj> objs = new List<TestObj>();
           objs.Add(new TestObj("1", Form1.SomeAction.Delete));
           objs.Add(new TestObj("2", Form1.SomeAction.Archive));
           objs.Add(new TestObj("3", Form1.SomeAction.Read));
           objs.Add(new TestObj("4", Form1.SomeAction.Update));
           objs.Add(new TestObj("5", Form1.SomeAction.Create));
           objs.Sort();
           foreach (var item in objs)
           {
               Console.WriteLine(item.ToString());
           }
