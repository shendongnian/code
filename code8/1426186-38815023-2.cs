     public bool ItemIsExist(ArrayList al, int id)
        {
            var NotInArryList = al.ToArray().Where(x => !al.Contains(id));
            var flag = NotInArryList.Count() == 0;
            Console.WriteLine("{0}  {1}", id, flag ? " Is Exist" : "Not Exist");
            return flag;
        }
