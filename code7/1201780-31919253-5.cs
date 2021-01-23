     List<MyClass> files  = new List<MyClass>();             
     foreach (DirectoryInfo folder in dirArr)
     {
                files.Add(new MyClass { Text = "", Value = "", FirstName = "", LastName = "", Addresss = "" });
     }
     GridView.DataSource = files;
     GridView.DataBind();
    
