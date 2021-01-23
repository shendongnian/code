    class SearchCriteria
    {
       public string Name { get; set; }
       public string Email { get; set; }
       public string Company { get; set; }
       // ... around 20 fields follow
    
       public void Trim()
       {
           typeof(SearchCriteria).GetProperties()
                 .Where (w =>w.PropertyType==typeof(string))
                 .ToList().ForEach(f=>
    		     {
    			     var value=f.GetValue(this);
    			     if(value!=null && !string.IsNullOrEmpty(value.ToString()))
    			     {
    				    f.SetValue(this,value.ToString().Trim(),null);
    			     }
    		     });
       }
    }
