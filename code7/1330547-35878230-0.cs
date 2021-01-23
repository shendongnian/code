    public async Task Foo()
    {
        
        // some synchronous code (no await)
        ...
        if (someCondition)
        { 
           return Task.FromResult(0);
        }
        return SomeOtherMethodThatReturnsTask();
    }
