        public void foo(List<Control> foundSofar, Control parent) 
        {
            foreach(var c in parent.Controls) 
            {
                  if(c is ComboBox) //Or whatever that is you checking for 
                  {
                         c.Attributes.Add("style", "color: aqua");
                  }
            }  
        }
