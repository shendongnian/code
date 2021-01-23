        List<Person> completeList = new List<Person>();
        completeList.AddRange(list[0].GetCompleteList());
        completeList.AddRange(list[1].GetCompleteList());
    
        // Another way: with linq
        var myPersons  list.SelectMany(m => m.GetCompleteList());
    
        public List<Person> GetCompleteList()
         {
             List<Person> returnList = new List<Person>();
             returnList.Add(this);
             if (person != null)
             {
                 returnList.AddRange(person.GetCompleteList());
             }
             return returnList;
         }
