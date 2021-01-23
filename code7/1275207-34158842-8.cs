    $ csharp
    Mono C# Shell, type "help;" for help
    
    Enter statements below.
    csharp> public class ProgramEntry {
          >  
          >     public long Id;
          >     public string Name;
          >     public long VM;
          >     public long Vm;
          >  
          >     public ProgramEntry (long id, string name, long vM, long vm) {
          >         Id = id;
          >         Name = name;
          >         VM = vM;
          >         Vm = vm;
          >     }
          >  
          >     public override string ToString () {
          >         return this.Id+":"+this.Name+"("+this.VM+"."+this.Vm+")";
          >     }
          >  
          > }
    csharp> List<ProgramEntry> programs = new List<ProgramEntry>();
    csharp> programs.Add(new ProgramEntry(1,"ssim",2,1));
    csharp> programs.Add(new ProgramEntry(2,"ssim",3,1)); 
    csharp> programs.Add(new ProgramEntry(3,"Counter",5,1));
    csharp> programs.Add(new ProgramEntry(4,"Counter",6,2)); 
    csharp> programs.Add(new ProgramEntry(5,"Counter",6,5)); 
    csharp> programs
    { 1:ssim(2.1), 2:ssim(3.1), 3:Counter(5.1), 4:Counter(6.2), 5:Counter(6.5) }
    csharp> var order = programs.OrderBy(x => -x.VM).ThenBy(x => -x.Vm);
    csharp> order
    { 5:Counter(6.5), 4:Counter(6.2), 3:Counter(5.1), 2:ssim(3.1), 1:ssim(2.1) }
    csharp> List<ProgramEntry> result = order.DistinctBy(x => x.Name).ToList();
    csharp> result
    { 5:Counter(6.5), 2:ssim(3.1) }
