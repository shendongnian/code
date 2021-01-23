      public IEnumerable<Sample> Filter(IEnumerable<Sample> collectionToFilter, int age, string name, string surname){
         if(!age.Equals(default(age))){
            collectionToFilter = collectionToFilter.Where(e=>e.Age==age);
         }
         if(!string.IsNullOrEmpty(name)){
            collectionToFilter = collectionToFilter.Where(e=>e.Name==name);
         }
         if(!string.IsNullOrEmpty(surname)){
            collectionToFilter = collectionToFilter.Where(e=>e.Surname==surname);
         }
         return collectionToFilter;
      }
