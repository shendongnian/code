    public Class CountryRegion
    {
        public CountryRegionHeader Header;
        public CountryRegionDetail Detail;
        public CountryRegionCode
        {
           //need some special logic here for the key since both Header or
           //Detail share the primary key and both may not be loaded
           get
           {
               if (Header != null)
                   return Header.CountryRegionCode;
               else
                   return Detail.CountryRegionCode; 
           }
           set
           {
               if (Header != null) Header.CountryRegionCode = value;
               if (Detail != null) Detail.CountryRegionCode = value;
           }
       }
       public string Name
       {
           get
           {
               return Header.Name;
           }
           set
           {
               Header.Name = value;
           }
       }
       public DateTime ModifiedDate
       {
           get
           {
                return Detail.ModifiedDate ;
           }
           set
           {
                Detail.ModifiedDate = value;
           }
       }
       public virtual ICollection<StateProvince> StateProvinces
       {
          get
          {
               return Detail.StateProvinces ;
          }
          set
          {
               Detail.StateProvinces = value;
          }
       }
    }
