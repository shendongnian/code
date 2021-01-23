    //suppose you have two Models
    public class student
    {
     public int Id
     public string Name{get;set;}
    }
    
    public class class
    {
     public int Id
     public string Name{get;set;}
    }
    
    // Now combine these two class Model in single Model for example:
    
    public class Mixmodel
    {
     public Student student {get;set;}
     public Class class {get;set;}
    }
    
    //here is the Home controller of the Index view
    
    @model projectName.MixModel
    
    @foreach(var item in Model.class)
    {
    @html.displayfor(item.class.Name)
    }
    
    @foreach(var item in Model.student)
    {
    @html.displayfor(item.student.Name)
    }
