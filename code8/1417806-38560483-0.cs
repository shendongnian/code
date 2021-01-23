         private void UpdateObjectToDB()
         {
            PUnit pUinit = new PUnit()
            {
                Id = this.Id,
                IsStarted = this.IsStarted,
                CImage = Encoding.ASCII.GetBytes(this.CImage) 
            };
            App.database.Update(pUinit);
        }
    
        public int InsertObjectToDB()
        {
            PUnit pUnit = new PUnit()
            {
                IsStarted = this.IsStarted,
                CCImage = Encoding.ASCII.GetBytes(this.CImage)
            };
            return App.database.AddItem(pUnit);
    }
