    using System;
    using FluentAssertions;
    namespace Demo
    {
        class ClassA
        {
            public NestedClassA A;
            public NestedClassB B;
        }
        class NestedClassA
        {
            public string S;
            public int I;
        }
        class NestedClassB
        {
            public char C;
            public double D;
        }
        class ClassB
        {
            public NestedClassC A;
            public NestedClassD B;
        }
        class NestedClassC
        {
            public string S;
            public int I;
        }
        class NestedClassD
        {
            public char C;
            public double D;
        }
        internal class Program
        {
            private static void Main()
            {
                var nestedA = new NestedClassA {I = 1, S = "1"};
                var nestedB = new NestedClassB {C = '1', D = 1};
                var nestedC = new NestedClassC { I = 1, S = "1" };
                var nestedD = new NestedClassD { C = '1', D = 1 };
                var classA = new ClassA {A = nestedA, B = nestedB};
                var classB = new ClassB {A = nestedC, B = nestedD};
                classA.ShouldBeEquivalentTo(classB); // Passes
                classB.ShouldBeEquivalentTo(classA); // Passes
                classB.B.D = 2; // Now the two objects do not contain equivalent data.
                classA.ShouldBeEquivalentTo(classB); // Fails.
            }
        }
    }
