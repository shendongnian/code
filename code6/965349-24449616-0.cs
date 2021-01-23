    static void Main(string[] args)
        {
            List<ProcessSteps> objSteps = new List<ProcessSteps>();
            // for step 1 
            ProcessSteps obj = new ProcessSteps();
            obj.id = 1;
            obj.name = "v2k";
            obj.Step = 1;
            objSteps.Add(obj);
            // for step 2
            ProcessSteps obj2 = new ProcessSteps();
            obj2.id = 2;
            obj2.name = "vvk";
            obj2.Step = 2;
            objSteps.Add(obj2);
            foreach (var item in objSteps)
            {
                Console.WriteLine(item.name);
            }
            
            Console.ReadLine();
        }
