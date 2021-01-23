    var st = new StackTrace();
    var errorInfo = String.Join("...", st.GetFrames().Select(x => 
        {
            var m = x.GetMethod();
            var t = m.DeclaringType;
            return String.Format("{0}.{1} @ {2}:{3}:{4}", t == null ? "" : t.Name, m.Name, x.GetFileName(), x.GetFileLineNumber(), x.GetFileColumnNumber());
        });
