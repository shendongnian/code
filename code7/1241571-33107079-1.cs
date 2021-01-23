     using (var db = new EFContext())
        {
            MyEntity me = new MyEntity();
            me.Name = "Bob";
            me.Age = 25;
            me.OtherData = "he does stuff";
            me.BlaBlaList = new List<int> { 7, 8, 9 };
            MyDBEntity newEntity = me.ConvertToDBEntity();
    
            db.Entities.Add(newEntity);
            db.SaveChanges();
        }
