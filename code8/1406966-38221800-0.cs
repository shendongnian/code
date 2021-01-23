    public class SemestersModel  : IEquatable<SemestersModel >{
    public string SemesterID  { get; set; }
    public string SemesterText  { get; set; }
    public bool Equals(SemestersModel comp)
    {
        if (SemesterID == comp.SemesterID && SemesterText == comp.SemesterText)
            return true;
        return false;
    }
    public override int GetHashCode()
    {
        int hSemesterID = SemesterID == null ? 0 : SemesterID.GetHashCode();
        int hSemesterText = SemesterText == null ? 0 : SemesterText.GetHashCode();
        return hSemesterID ^ hSemesterText;
    }}
