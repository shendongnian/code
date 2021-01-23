    public static class DirectoryInfoExtensions
    {
        public static JObject ToJson<TResult>(this DirectoryInfo info, Func<FileInfo, TResult> getData)
        {
            return new JObject
                (
                info.GetFiles().Select(f => new JProperty(f.Name, getData(f))).Concat(info.GetDirectories().Select(d => new JProperty(d.Name, d.ToJson(getData))))
                );
        }
    }
