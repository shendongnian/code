    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("List<int>");
            new List<int> { 1, 2, 3 }
                .DoSomething()
                .DoSomething();
            Console.WriteLine("List<string>");
            new List<string> { "a", "b", "c" }
                .DoSomething()
                .DoSomething();
            Console.WriteLine("int[]");
            new int[] { 1, 2, 3 }
                .DoSomething()
                .DoSomething();
            Console.WriteLine("string[]");
            new string[] { "a", "b", "c" }
                .DoSomething()
                .DoSomething();
            Console.WriteLine("nongeneric collection with ints");
            var stack = new System.Collections.Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack
                .DoSomething()
                .DoSomething();
            Console.WriteLine("nongeneric collection with mixed items");
            new System.Collections.ArrayList { 1, "a", null }
                .DoSomething()
                .DoSomething();
            Console.WriteLine("nongeneric collection with .. bits");
            new System.Collections.BitArray(0x6D)
                .DoSomething()
                .DoSomething();
        }
    }
    public static class MyGenericUtils
    {
        public static System.Collections.IEnumerable DoSomething(this System.Collections.IEnumerable items)
        {
            // check the REAL type of incoming collection
            // if it implements IEnumerable<T>, we're lucky!
            // we can unwrap it
            // ...usually. How to unwrap it if it implements it multiple times?!
            var ietype = items.GetType().FindInterfaces((t, args) =>
                t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>),
                null).SingleOrDefault();
            if (ietype != null)
            {
                return
                    doSomething_X(
                        doSomething_X((dynamic)items)
                    );
                    // .doSomething_X() - and since the compile-time type is 'dynamic' I cannot chain
                    // .doSomething_X() - it in normal way (despite the fact it would actually compile well)
                   // `dynamic` doesn't resolve extension methods!
                   // it would look for doSomething_X inside the returned object
                   // ..but that's just INTERNAL implementation. For the user
                   // on the outside it's chainable
            }
            else
                // uh-oh. no what? it can be array, it can be a non-generic collection
                // like System.Collections.Hashtable .. but..
                // from the type-definition point of view it means it holds any
                // OBJECTs inside, even mixed types, and it exposes them as IEnumerable
                // which returns them as OBJECTs, so..
                return items.Cast<object>()
                    .doSomething_X()
                    .doSomething_X();
        }
        private static IEnumerable<T> doSomething_X<T>(this IEnumerable<T> valitems)
        {
            // do-whatever,let's just see it being called
            Console.WriteLine("I got <{1}>: {0}", valitems.Count(), typeof(T));
            return valitems;
        }
    }
