    private static bool IsDebug()
    {
        // Taken from http://stackoverflow.com/questions/2104099/c-sharp-if-then-directives-for-debug-vs-release
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(DebuggableAttribute), false);
        if ((customAttributes != null) && (customAttributes.Length == 1))
        {
            DebuggableAttribute attribute = customAttributes[0] as DebuggableAttribute;
            return (attribute.IsJITOptimizerDisabled && attribute.IsJITTrackingEnabled);
        }
        return false;
    }
    static void Main(string[] args)
    {
        // Check x86 or x64
        Console.WriteLine(IntPtr.Size == 4 ? "x86" : "x64");
        // Check Debug/Release
        Console.WriteLine(IsDebug() ? "Debug, USELESS BENCHMARK" : "Release");
        // Check if debugger is attached
        Console.WriteLine(System.Diagnostics.Debugger.IsAttached ? "Debugger attached, USELESS BENCHMARK!" : "Debugger not attached");
        Console.WriteLine();
        {
            long memory = GC.GetTotalMemory(true);
            // A big array, big enough that we can see its allocation in
            // memory
            byte[] buffer = new byte[10000000];
            Console.WriteLine("Just allocated the array: {0}", GC.GetTotalMemory(true) - memory);
            // A List<>, containing a reference to the buffer
            List<object> myList = new List<object>();
            myList.Add(buffer);
            Console.WriteLine("Added to the List<>: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that buffer is referenced at least up to
            // this point
            GC.KeepAlive(buffer);
            // But clearly setting buffer = null is useless, because the
            // List<> has anothe reference
            buffer = null;
            Console.WriteLine("buffer = null: {0}", GC.GetTotalMemory(true) - memory);
            // If I Clear() the List<>, the last reference to the buffer
            // is removed, and now the buffer can be freed
            myList.Clear();
            Console.WriteLine("myList.Clear(): {0}", GC.GetTotalMemory(true) - memory);
            GC.KeepAlive(myList);
        }
        Console.WriteLine();
        GC.Collect();
        {
            long memory = GC.GetTotalMemory(true);
            // A big array, big enough that we can see its allocation in
            // memory
            byte[] buffer = new byte[10000000];
            Console.WriteLine("Just allocated the array: {0}", GC.GetTotalMemory(true) - memory);
            // A List<>, containing a reference to the buffer
            List<object> myList = new List<object>();
            myList.Add(buffer);
            Console.WriteLine("Added to the List<>: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that buffer is referenced at least up to
            // this point
            GC.KeepAlive(buffer);
            // But clearly setting buffer = null is useless, because the
            // List<> has another reference
            buffer = null;
            Console.WriteLine("buffer = null: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that the List<> is referenced at least
            // up to this point
            GC.KeepAlive(myList);
            // If I set to null myList, the last reference to myList
            // and to buffer are removed
            myList = null;
            Console.WriteLine("myList = null: {0}", GC.GetTotalMemory(true) - memory);
        }
        Console.WriteLine();
        GC.Collect();
        {
            long memory = GC.GetTotalMemory(true);
            // A big array, big enough that we can see its allocation in
            // memory
            byte[] buffer = new byte[10000000];
            Console.WriteLine("Just allocated the array: {0}", GC.GetTotalMemory(true) - memory);
            // A List<>, containing a reference to the buffer
            List<object> myList = new List<object>();
            myList.Add(buffer);
            Console.WriteLine("Added to the List<>: {0}", GC.GetTotalMemory(true) - memory);
            // A predicate, containing a reference to myList
            Expression<Func<object, bool>> predicate1 = p => myList.Contains(p);
            Console.WriteLine("Created a predicate p => myList.Contains(p): {0}", GC.GetTotalMemory(true) - memory);
            // A second predicate, **not** containing a reference to
            // myList
            Expression<Func<object, bool>> predicate2 = p => p.GetHashCode() == 0;
            Console.WriteLine("Created a predicate p => p.GetHashCode() == 0: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that buffer is referenced at least up to
            // this point
            GC.KeepAlive(buffer);
            // But clearly setting buffer = null is useless, because the
            // List<> has another reference
            buffer = null;
            Console.WriteLine("buffer = null: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that the List<> is referenced at least
            // up to this point
            GC.KeepAlive(myList);
            // If I set to null myList, an interesting thing happens: the
            // memory is freed, even if the predicate1 is still alive!
            myList = null;
            Console.WriteLine("myList = null: {0}", GC.GetTotalMemory(true) - memory);
            // We want to be sure that the predicates are referenced at 
            // least up to this point
            GC.KeepAlive(predicate1);
            GC.KeepAlive(predicate2);
            try
            {
                // We compile the predicate1
                Func<object, bool> fn = predicate1.Compile();
                // And execute it!
                fn(5);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("predicate1 is 'pointing' to a null myList");
            }
        }
    }
