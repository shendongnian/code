    public class MyDependency<T> : IMyDependency<T>
    {
        private string objectName = typeof(T).Name;
        public void WhatGenericTypeIAm()
        {
            Console.WriteLine("My generic type is " + objectName);
        }
    }
