    var combined = corporateFiles.Union(functionalFiles, new FileNameComparer())
    class FileNameComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            var name1 = Path.GetFileName(x);
            var name2 = Path.GetFileName(y);
            return name1 == name2;
        }
        public override int GetHashCode(string obj)
        {
            var name = Path.GetFileName(obj);
            return name.GetHashCode();
        }
    }
