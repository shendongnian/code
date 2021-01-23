    public enum EnumOrder {
    	Bad = -1, Zero = 0, One = 1 }
    public class ClassOrder {
    	public int first;
    	public int second;
    	public int First { get { return first; } }
    	public int Second { get { return second; } } }
    private void PrintInfos<T>(IEnumerable<T> list) where T: MemberInfo {
    	foreach(var e in list) memo.AppendLine(e.Name); }
    private void ReflectionOrderTest(object sender, EventArgs e) {
    	typeof(EnumOrder).GetField("One");
    	typeof(ClassOrder).GetField("second");
    	typeof(ClassOrder).GetProperty("Second");
    	memo.AppendLine("First time order:");
    	PrintInfos(typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic));
    	PrintInfos(typeof(ClassOrder).GetFields());
    	PrintInfos(typeof(ClassOrder).GetProperties());
    	memo.AppendLine("Broken order:");
    	PrintInfos(typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic));
    	PrintInfos(typeof(ClassOrder).GetFields());
    	PrintInfos(typeof(ClassOrder).GetProperties());
    	memo.AppendLine("MetadataToken Sorted:");
    	PrintInfos(typeof(EnumOrder).GetFields().Where(fi => fi.IsStatic).OrderBy(fi => fi.MetadataToken));
    	PrintInfos(typeof(ClassOrder).GetFields().OrderBy(fi => fi.MetadataToken));
    	PrintInfos(typeof(ClassOrder).GetProperties().OrderBy(fi => fi.MetadataToken));
    }
