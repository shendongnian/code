    internal void WriteZip(ZipOutputStream os)
    {
        ...code...
        if (_rels.Count > 0)
        {
            string f = Uri.OriginalString;
            var name = Path.GetFileName(f);
            _rels.WriteZip(os, (string.Format("{0}_rels/{1}.rels", f.Substring(0, f.Length - name.Length), name)));
        }
        ...code...
    }
