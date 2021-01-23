        public School Insert(School newItem, int cityId)
        {
            if(cityId <= 0)
            {
                throw new Exception("City ID no provided");
            }
            newItem.City = null;
            newItem.City_Id = cityId;
            using (var context = new DatabaseContext())
            {
                context.Set<School>().Add(newItem);
                context.SaveChanges();
                return newItem;
            }
        }
