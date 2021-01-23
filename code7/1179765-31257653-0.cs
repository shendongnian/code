    Get["/somedata"] = _ => new MyModelEx
       { 
          WhateverRealProperty = "some data",
          RequestUri = this.Context.Request.Uri
       };
    
    public class MyModelEx : MyModel, IModelWithRequestUri
    {
        public string RequestUri {get; set;}
    }
