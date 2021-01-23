    public enum EnumOrder {
    	Bad = -1, Zero = 0, One = 1 }
    public class ClassOrder {
    	public int first;
    	public int First { get { return first; } }
    	public int second;
    	public int Second { get { return second; } } }
    private void PrintInfos<T>(string head, IEnumerable<T> list) where T: MemberInfo {
    	memo.AppendText(string.Format("  {0}: ", head));
    	bool first = true; foreach(var e in list) {
    		if(first) first = false; else memo.AppendText(", ");
    		memo.AppendText(e.Name); }
    	memo.AppendText("\r\n"); }
    private void ReflectionOrderTest(object sender, EventArgs e) {
    	typeof(EnumOrder).GetField("One");
    	typeof(ClassOrder).GetField("second");
    	typeof(ClassOrder).GetProperty("Second");
    	memo.AppendLine("First time order:");
    	PrintInfos("Enum", typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic));
    	PrintInfos("Fields", typeof(ClassOrder).GetFields());
    	PrintInfos("Properties", typeof(ClassOrder).GetProperties());
    	PrintInfos("Members", typeof(ClassOrder).GetMembers());
    	memo.AppendLine("Broken order:");
    	PrintInfos("Enum", typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic));
    	PrintInfos("Fields", typeof(ClassOrder).GetFields());
    	PrintInfos("Properties", typeof(ClassOrder).GetProperties());
    	PrintInfos("Members", typeof(ClassOrder).GetMembers());
    	memo.AppendLine("MetadataToken Sorted:");
    	PrintInfos("Enum", typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic).OrderBy(fi => fi.MetadataToken));
    	PrintInfos("Fields", typeof(ClassOrder).GetFields().OrderBy(fi => fi.MetadataToken));
    	PrintInfos("Properties", typeof(ClassOrder).GetProperties().OrderBy(fi => fi.MetadataToken));
    	PrintInfos("Members", typeof(ClassOrder).GetMembers().OrderBy(fi => fi.MetadataToken));
    }
