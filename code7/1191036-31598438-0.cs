    public class MyGridClass
    {
    	public string FileName { get; set; }
    	public string Directory { get; set; }
    	public string Number { get; set; }
    	public string Prop1 { get; set; }
    	public string Prop2 { get; set; }
    }
    NesInfo ni = ...
    MyGridClass gc = new MyGridClass ( );
    gc.FileName = ni.FileName;
    gc.Directory = ni.Directory;
    gc.Number = ni.MapperInfo.Number;
    gc.Prop1 = ni.MapperInfo.Prop1;
    gc.Prop2 = ni.MapperInfo.Prop2;
