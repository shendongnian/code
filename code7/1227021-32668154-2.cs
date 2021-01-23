    var procinfo = new ProcessInfo{
                       ProcessId = "1",
                       ...
                   };
    var serialised = JsonConvert.SerializeObject(procinfo);
    var bytes = Encoding.Utf8.GetBytes(serialised);
    ns.Write(bytes, 0, bytes.Length);
