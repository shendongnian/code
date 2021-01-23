    case 1://BSIT
    {
         iden = 0;
         Console.Write("Enter Name: ");
    	 //here you'll initialize the object
    	 students[studCount, iden] = new BSIT();	//Student is base, so it can contain all of it's child objects
    	 
         (students[studCount, iden]).setName(Console.ReadLine());
         do
         {
            Console.Write("Enter Age(15-30 only): ");
            int a = int.Parse(Console.ReadLine());
    
            if(a>=15 && a<=30)
            {
                (students[studCount, iden]).setAge(a);
                valid=1;
            }
            else
            {
                valid=0;
                Console.WriteLine("INVALID INPUT. TRY AGAIN.");
            }
         }
         while(valid==0);
    }
    
    case 2://BSCS
    {
        iden = 1;
        Console.Write("Enter Name: ");
        (s3[studCount,iden]).setName(Console.ReadLine());  
    
    	iden = 1;
         Console.Write("Enter Name: ");
    	 //here you'll initialize the object
    	 students[studCount, iden] = new BSCS();	//Student is base, so it can contain all of it's child objects (here we're initializing BSCS)
    	 
    	(students[studCount, iden]).setName(Console.ReadLine()); 
    	//your code...
