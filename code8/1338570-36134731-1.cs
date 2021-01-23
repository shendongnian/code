     static void Main(string[] args)
            {
    
                List<ClassA> listA = new List<ClassA> ();
                List<ClassB> listB = new List<ClassB>();
                ClassA a = new ClassA();
                a.Number = 1; a.Status = false;
                ClassA a2 = new ClassA();
                a2.Number = 1; a2.Status = true;
                ClassA a3 = new ClassA();
                a3.Number = 1; a3.Status = true;
                ClassA a4 = new ClassA();
                a4.Number = 1; a4.Status = true;
    
                ClassB b1 = new ClassB();
                b1.Number = 2;b1.Status = true;
                ClassB b2 = new ClassB();
                b2.Number = 3; b2.Status = false;
                ClassB b3 = new ClassB();
                b3.Number = 2; b3.Status = true;
                ClassB b4 = new ClassB();
                b4.Number = 3; b4.Status = false;
                listA.Add(a);
                listA.Add(a2);
                listA.Add(a3);
                listA.Add(a4);
                listB.Add(b1);
                listB.Add(b2);
                listB.Add(b3);
                listB.Add(b4);
                listA.AddRange(listB.Select(o => new ClassA() { Status = o.Status }));
            }
