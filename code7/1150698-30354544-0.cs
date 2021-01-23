<pre>
    class Class1
    {
        Class2 _class2;
        public Class1(Class2 class2)
        {
            _class2 = class2;
        }
        public void method3()
        {
            //call _class2.method4()
        }
    }
    class Class2
    {
        Class1 _class1;
        public Class2(Class1 class1)
        {
            _class1 = class1;
        }
        public void Method4()
        {
            //call _class1.MethodWhatever()
        }
    }
</pre>
