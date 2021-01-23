    void ABC()
    {
        var A = new Person("A");
        var B = new Person("B");
        var C = new Person("C");
        List<Person> newPersonList = new List<Person>();
        newPersonList.Add(A);
        newPersonList.Add(B);
        newPersonList.Add(C);
        
        newPersonList.Remove(A);
    }
