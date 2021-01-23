            MyEnumerableClass myEnumerableClass = new MyEnumerableClass();
            foreach (var item in myEnumerableClass)
            {
                Console.WriteLine(item);
            }
            IEnumerator enumerator = myEnumerableClass.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
