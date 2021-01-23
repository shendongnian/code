    public void DoSomething()
    {
    	// Add a new block for everyone called Bob
    	people.AddNested(p => p.Blocks, p => p.FirstName == "Bob", p => new Block("Block For Bob"));
    	
    	// Add a new block for Bob Mackey
    	people.AddNested(p => p.Blocks, p => p.FirstName == "Bob" && p.Surname == "Mackey", 
    		p => new Block());
    		
    	// Add for specific item
    	var person = people.Single(p => p.Surname == "dfsdfdfsdf");
    	var block = CreateBlockForPerson(person);
    	people.NestedAdd(p => p.Blocks, person, block);
    }
