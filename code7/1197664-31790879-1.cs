            var listA = new List<IHuman>();
            listA.Add(new HumanA());
            listA.Add(new HumanA());
            listA.Add(new HumanA());
            var listB = new List<IHuman>(listA);
            
            var humanB = (HumanB)listB[0];
