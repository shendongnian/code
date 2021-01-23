    public abstract class MyIdAttribute: Attribute
    {
    }
    
    public class MyClass
    {
        [MyId]
        WhatEverName {get; set;}
    }
