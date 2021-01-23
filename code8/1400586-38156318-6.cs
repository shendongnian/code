    class TelegramResponse<T>
    {
        public bool ok { get; set; }
        public T result { get; set; }
    }
    class FileInfo
    {
        public string file_path { get; set; }
    }
