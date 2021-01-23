         public class Folder
         {
           [Key]
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           public int Id { get; set; }
           public string Name { get; set; }
           public virtual ICollection<Letter> Letters { get; set; }
           public override bool Equals(object obj)
           {
              var folder = obj as Folder;
              return folder.Id == this.Id && folder.Name == this.Name &&
                folder.Letters.SequenceEqual(this.Letters);
           }
           public override int GetHashCode()
           {
              return String.Concat(GetHashParts()).GetHashCode();
           }
           private IEnumerable<string> GetHashParts()
           {
              yield return Id.ToString();
              yield return Name;
              foreach (var letter in Letters) {
                  yield return "_";
                  yield return letter.Id.ToString();
              }
           }
           public static bool operator ==(Folder x, Folder y)
           {
               return x.Equals(y);
           }
           public static bool operator !=(Folder x, Folder y)
           {
              return !x.Equals(y);
           }
       }
