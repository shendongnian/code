    public void AddClass(string classname ){
    // add a class
    myMenu.CssClass = String.Join(" ", myMenu
               .CssClass
               .Split(' ')
               .Except(new string[]{"",classname})
               .Concat(new string[]{classname})
               .ToArray()
       );
    }
